    public static void GenerateRandom(byte[] data, bool nonZeroOnly = false)
    {
        using (var generator = RandomNumberGenerator.Create())
        {
            if (nonZeroOnly) { generator.GetNonZeroBytes(data); }
            else { generator.GetBytes(data); }
        }
    }
    public static void GenerateRandom(short[] data, bool nonZeroOnly = false)
    {
        var size = sizeof(short);
        var bytes = new byte[data.Length * size];
    
        GenerateRandom(bytes, nonZeroOnly);
        for (var i = 0; i < data.Length; ++i) {
            data[i] = BitConverter.ToInt16(bytes, i * size);
        }
    }
