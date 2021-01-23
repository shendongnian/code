    static private List<T> AmplifyPCM<T>(ICollection<T> samples, ushort bitDepth, float volumePercent)
    {
        var highestSample = 0;
        var temp = new List<T>();
        foreach (var sample in samples)
        {
            if ((dynamic)sample < 0)
            {
                temp.Add(-(dynamic)sample);
            }
            else
            {
                temp.Add(sample);
            }
        }
        foreach (var sample in temp)
        {
            if ((dynamic)sample > highestSample)
            {
                highestSample = (dynamic)sample;
            }
        }
        temp = null;
        var ratio = (volumePercent * (Math.Pow(2, bitDepth) / 2)) / highestSample;
        var newSamples = new List<T>();
        foreach (var sample in samples)
        {
            newSamples.Add((dynamic)(T)sample * ratio);
        }
        return newSamples;
    }
