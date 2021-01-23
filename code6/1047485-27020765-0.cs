    static string HexToBase64(string hex)
    {
        byte[] buf = new byte[hex.Length / 2];
        for (int i = 0; i < hex.Length / 2; i++)
        {
            buf[i] = Convert.ToByte(hex.Substring(i*2,2), 16);
        }
        return Convert.ToBase64String(buf);
    }
