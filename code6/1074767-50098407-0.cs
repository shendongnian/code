    public static Texture2D ArrayToTexture2d(Image<Rgb, byte> picture) {
        Array bytes = picture.ManagedArray;
        int h = bytes.GetLength(0);
        int w = bytes.GetLength(1);
        Texture2D t2d = new Texture2D(w, h);
        double r, b, g;
        for (int heigth = 0; heigth < bytes.GetLength(0); heigth++)
        {
            for (int width = 0; width < bytes.GetLength(1); width++)
            {
                r = Convert.ToDouble(bytes.GetValue(heigth, width, 0));
                g = Convert.ToDouble(bytes.GetValue(heigth, width, 1));
                b = Convert.ToDouble(bytes.GetValue(heigth, width, 2));
                t2d.SetPixel(width, h - heigth - 1, new Color((float)r / 256, (float)g / 256, (float)b / 256, 1f));                
            }
        }
        t2d.Apply();
        return t2d;
    }
