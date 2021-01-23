    foreach (var color in GetColors(10))
    {
        b.MakeTransparent(color);
    }
    
    IEnumerable<Color> GetColors(int interval)
    {
        for (var r = 255; r > 255 - interval; --r)
        {
            for (var g = 255; g > 255 - interval; --g)
            {
                for (var b = 255; b > 255 - interval; --b)
                {
                    yield return Color.FromArgb(r, g, b);
                }
            }
        }
        // Or
        //return from r in Enumerable.Range(255 - interval, interval)
        //       from g in Enumerable.Range(255 - interval, interval)
        //       from b in Enumerable.Range(255 - interval, interval)
        //       select Color.FromArgb(r, g, b);
    }
