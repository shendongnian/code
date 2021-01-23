    public static double MAXIMUM_HEIGHT = 400.0;
    public static Dictionary<string, int> BuildThumbSizeOptions()
    {
        ThumbSizeOptions = new Dictionary<string, int>();
    
        for (int perc = 10; perc <= 100; perc += 10)
        {
            var size = MAXIMUM_HEIGHT / 100.0 * perc;
            ThumbSizeOptions.Add(perc + "%", (int)size);
        }
        return ThumbSizeOptions;
    }
