    public static byte[] StringToByteArray(string hex) 
    {
        if((hex.Length % 2) != 0)
            hex = "0" + hex;
            
        return Enumerable.Range(0, hex.Length)
                         .Where(x => x % 2 == 0)
                         .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                         .ToArray();
    }
