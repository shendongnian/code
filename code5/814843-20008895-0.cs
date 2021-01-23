    public static Dictionary<string, int> BuildThumbSizeOptions()
    {
        ThumbSizeOptions = new Dictionary<string, int>();
    
        var max = (double)SizeType.Height_100_Pct;
        foreach (int val in Enum.GetValues(typeof(SizeType)))
        {
            double perc = 100.0 / max * (double)val;
            ThumbSizeOptions.Add(perc + "%", val);
        }
        return ThumbSizeOptions;
    }
