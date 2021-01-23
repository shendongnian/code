    private Color AdjustBrightness(double brightnessFactor)
    {
        Color originalColour = Color.Red;
        Color adjustedColour = Color.FromArgb(originalColour.A, 
            (int)(originalColour.R * brightnessFactor), 
            (int)(originalColour.G * brightnessFactor), 
            (int)(originalColour.B * brightnessFactor));
        return adjustedColour;
    }
