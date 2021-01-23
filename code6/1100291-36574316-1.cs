    private Windows.UI.Color GetColorFromHex(string hexString)
    {
        hexString = hexString.Replace("#", string.Empty);
        byte r = byte.Parse(hexString.Substring(0, 2), NumberStyles.HexNumber);
        byte g = byte.Parse(hexString.Substring(2, 2), NumberStyles.HexNumber);
        byte b = byte.Parse(hexString.Substring(4, 2), NumberStyles.HexNumber);
        return Windows.UI.Color.FromArgb(byte.Parse("1"), r, g, b);
    }
