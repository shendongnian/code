    for (int i = 0; i < ht; ++i)
    {
        for (int j = 0; j < wid; ++j)
        {
            Color pixel = myimage.GetPixel(j,i);
            if (pixel == Color.FromArgb(0, 0, 0)) black++;
            else if (pixel == Color.FromArgb(255, 255, 255)) white++;
        }
    }
    Console.WriteLine(black + " black  and " + white + " white pixels of of " + sum);
