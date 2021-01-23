    private SolidColorBrush GetBrushFromHexString(string hexString)
        {
            hexString = hexString.Replace("#", "");
            int colorInt = Int32.Parse(hexString, NumberStyles.HexNumber);
            byte a = (byte)(colorInt >> 24);
            byte r = (byte)(colorInt >> 16);
            byte g = (byte)(colorInt >> 8);
            byte b = (byte)colorInt;
            Color color = Color.FromArgb(a, r, g, b);
            return new SolidColorBrush(color);
        }
    FillVal = GetBrushFromHexString("#FF7CB84D");
