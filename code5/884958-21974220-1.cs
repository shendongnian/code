    public static HSVData RGBtoHSV(Color RGB)
    {
        double r = (double)RGB.R / 255;
        double g = (double)RGB.G / 255;
        double b = (double)RGB.B / 255;
        double h;
        double s;
        double v;
        double min = Math.Min(Math.Min(r, g), b);
        double max = Math.Max(Math.Max(r, g), b);
        v = max;
        double delta = max - min;
        if (max == 0 || delta == 0)
        {
            s = 0;
            h = 0;
        }
        else
        {
            s = delta / max;
            if (r == max)
            {
                // Between Yellow and Magenta
                h = (g - b) / delta;
            }
            else if (g == max)
            {
                // Between Cyan and Yellow
                h = 2 + (b - r) / delta;
            }
            else
            {
                // Between Magenta and Cyan
                h = 4 + (r - g) / delta;
            }
        }
        h *= 60;
        if (h < 0)
        {
            h += 360;
        }
        return new HSVData()
        {
            h = h,
            s = s,
            v = v
        };
    }
