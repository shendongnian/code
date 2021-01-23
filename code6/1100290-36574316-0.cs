    private Windows.UI.Color GetColorFromHex(string hexString)
    {
        hexString = hexString.Replace("#", "");
        byte a = byte.Parse(hexString.Substring(1, 2), NumberStyles.HexNumber);
        byte r = byte.Parse(hexString.Substring(3, 2), NumberStyles.HexNumber);
        byte g = byte.Parse(hexString.Substring(5, 2), NumberStyles.HexNumber);
        byte b = byte.Parse(hexString.Substring(7, 2), NumberStyles.HexNumber);
        return Windows.UI.Color.FromArgb(a, r, g, b);
    }
