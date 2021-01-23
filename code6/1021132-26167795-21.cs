    SolidBrush MixColor(SolidBrush b1, SolidBrush b2)
    {
        return new SolidBrush(Color.FromArgb(Math.Max(b1.Color.A, b2.Color.A),
                             (b1.Color.R + b2.Color.R) / 2, (b1.Color.G + b2.Color.G) / 2,
                             (b1.Color.B + b2.Color.B) / 2));
    }
