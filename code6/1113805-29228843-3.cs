    Dictionary<Color, long> colorCount = new Dictionary<Color, long>();
    for (int i = 0; i < ht; ++i)
    {
        for (int j = 0; j < wid; ++j)
        {
            Color pixel = myimage.GetPixel(j, i);
            if (colorCount.ContainsKey(pixel)) colorCount[pixel]++;
            else colorCount.Add(pixel, 1);
        }
    }
    foreach (Color c in colorCount.Keys)
        Console.WriteLine( c.ToString() + " occurs " + colorCount[c] + " times.");
