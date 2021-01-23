    public static Bitmap RemovePart(Bitmap source, Bitmap toRemove)
    {
        Color c1, c2, c3;
        c3 = Color.FromArgb(0, 0, 0, 0);
        for (int x = 0; x < source.Width; x++)
        {
           for (int y = 0; y < source.Height; y++)
           {
               c1 = source.GetPixel(x, y);
               c2 = toRemove.GetPixel(x, y);
               if (c2 != c3)
               {
                   source.SetPixel(x, y, Color.FromArgb(c2.A, c1));
               }
           }
        }
    }
