    public static RectangleF MeasureStringBounds(Graphics graphics, string text, Font  font,RectangleF bounding, StringFormat format)
    {
        var ranges =new[] {new CharacterRange(0, text.Length)};
        format.SetMeasurableCharacterRanges(ranges);
        var regions = graphics.MeasureCharacterRanges(text, font, bounding, format);
        var accurateBoundings = regions[0].GetBounds(graphics);
        return accurateBoundings;
    }
