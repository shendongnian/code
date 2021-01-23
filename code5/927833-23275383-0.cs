    private static void ChangeColor()
    {
        foreach (MultiIcon mi in listMi)
            foreach (SingleIcon si in mi)
                for (int n = 0; n < si.Count(); n++)
                {
                    IconImage ii = si[n];
                    Bitmap img = new Bitmap(ii.Image);
                    for (int w = 0; w < img.Width; w++)
                        for (int h = 0; h < img.Height; h++)
                            img.SetPixel(w, h, Color.Red);
                    ii.Set(img, null, Color.Transparent);
                }
    }
