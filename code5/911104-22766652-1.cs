    static public string DeMangleCode(string argMangledCode)
    {
        Encoding enc = Encoding.GetEncoding(1252);
        byte[] argMangledCodeBytes = enc.GetBytes(argMangledCode);
        List<byte> unencrypted = new List<byte>();
        for (int temp = 0; temp < argMangledCodeBytes.Length; temp++)
        {
            unencrypted.Add((byte)(argMangledCodeBytes[temp] ^ (434 + temp) % 255));
        }
        return enc.GetString(unencrypted.ToArray());
    }
