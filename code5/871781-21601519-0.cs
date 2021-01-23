    static byte hexstr2byte(string s)
    {
        if (!s.StartsWith("0x") || s.Length != 4)
            throw new FormatException();
        return byte.Parse(s.Substring(2), System.Globalization.NumberStyles.HexNumber);
    }
