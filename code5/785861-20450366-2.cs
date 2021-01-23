    unsafe static int[] GenerateRandom(int length, int minInclusive, int maxExclusive)
    {
        var bytes = new byte[length * 4];
        var ints = new int[length];
        var ratio = uint.MaxValue / (double)(maxExclusive - minInclusive);
        using (RandomNumberGenerator generator = RandomNumberGenerator.Create())
        {
            generator.GetBytes(bytes);
            fixed(byte* b = bytes)
            {
                uint* i = (uint*)b;
                for(int j = 0; j < length; j++, i++)
                {
                    ints[j] = minInclusive + (int)(*i / ratio);
                }
            }
        }
        return ints;
    }
