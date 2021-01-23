    private void getShadesAndTints(Color c)
    {
        int i; Double factor;
        int r; int g; int b;
        for (i = 20; i >=0; i--)
        {
            factor = i/20;
            r = (int)(c.R * factor); if (r > 255) r = 255;
            g = (int)(c.G * factor); if (g > 255) g = 255;
            b = (int)(c.B * factor); if (b > 255) b = 255;
            colorList.Add(Color.FromArgb(r, g, b));
        }
    }
