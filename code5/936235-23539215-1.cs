    public SolidColorBrush GetBrushFromHexColor(string hexColor)
    {
        return new SolidColorBrush(
            Color.FromArgb(
                Convert.ToByte(hexColor.Substring(1, 2), 16),
                Convert.ToByte(hexColor.Substring(3, 2), 16),
                Convert.ToByte(hexColor.Substring(5, 2), 16),
                Convert.ToByte(hexColor.Substring(7, 2), 16)
            )
        );
    }
