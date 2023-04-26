using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    public AudioSource source;
    public float size = 10f;
    public float power = 2f;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float[] samples = new float[735];
        source.clip.GetData(samples, source.timeSamples);


        float sum = 0;
        foreach (var sample in samples)
        {
            sum += Mathf.Abs(sample);
        }
        float average = sum / 735;
        print(average);



        transform.localScale = Vector3.one * (1 + Mathf.Pow(average, power) * size);
        transform.Rotate(0, average, 0);
    }
}
