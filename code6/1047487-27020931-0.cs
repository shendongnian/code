    public static string HexToBase64String(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length % 2 == 1)
            throw new ArgumentException("Invalid hex value", "hex");
    
        var bytes = Enumerable.Range(0, hex.Length)
                         .Where(x => x % 2 == 0)
                         .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                         .ToArray();
        return System.Convert.ToBase64String(bytes);
    }
