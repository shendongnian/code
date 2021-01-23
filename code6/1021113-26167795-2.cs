    SolidBrush MixColorHSV(SolidBrush br1, SolidBrush br2)
    {
        Color c1 = br1.Color;
        Color c2 = br2.Color;
        double h = (c1.GetHue() + c2.GetHue()) / 2d;
        double s = (c1.GetSaturation() + c2.GetSaturation()) / 2d;
        double v = (c1.GetBrightness() + c2.GetBrightness()) / 2d;
        return new SolidBrush(ColorFromHSV(h,s,v) );
    }
    public static Color ColorFromHSV(double hue, double saturation, double value)
    {
        int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
        double f = hue / 60 - Math.Floor(hue / 60);
        value = value * 255;
        int v = Convert.ToInt32(value);
        int p = Convert.ToInt32(value * (1 - saturation));
        int q = Convert.ToInt32(value * (1 - f * saturation));
        int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));
        if (hi == 0)       return Color.FromArgb(255, v, t, p);
        else if (hi == 1)  return Color.FromArgb(255, q, v, p);
        else if (hi == 2)  return Color.FromArgb(255, p, v, t);
        else if (hi == 3)  return Color.FromArgb(255, p, q, v);
        else if (hi == 4)  return Color.FromArgb(255, t, p, v);
        else               return Color.FromArgb(255, v, p, q);
    }
