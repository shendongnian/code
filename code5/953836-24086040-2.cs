    static private List<T> AmplifyPCM(ICollection<T> samples, ushort bitDepth, float volumePercent)
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
            if (sample > highestSample)
            {
                highestSample = sample;
            }
        }
    
        temp = null;
    
        var ratio = (volumePercent * Math.Pow(2, bitDepth)) / highestSample; 
        var newSamples = new List<T>();
    
        foreach (var sample in samples)
        {
            newSamples.Add(sample * ratio); // ratio is of type double, therefore implicit conversion from whatever sample's type is to a double.
        }
    
        // switch statement would go here if there's no better way.
    
        return newSamples;
    }
