    public static List<byte[]> GetBuffers(int maxLength)
    {
        if (maxLength > 4) throw new InvalidOperationException("Fail");
        var result = new List<byte[]>();
        for (int i = 1; i <= maxLength; i++)
        {
            var max = 1 << (i * 8);
            for (long j = 0; j < max; j++)
            {
                // Can remove the Reverse() if endianness/ordering doesn't matter
                var buffer = BitConverter.GetBytes(j).Take(i).Reverse().ToArray());
                result.Add(buffer);
            }
        }
        return result;
    }
