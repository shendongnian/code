    public static string ByteArrayToString(byte[] ba)
    {
        if (BitConverter.IsLittleEndian)
             Array.Reverse(ba);
        
        string hex = BitConverter.ToString(ba);
        return hex.Replace("-", "");
    }
