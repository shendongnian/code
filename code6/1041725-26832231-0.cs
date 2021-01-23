    static void Unpermute(byte[] data, string seed)
    {
        Random random = new Random(seed.GetHashCode());
        List<int> swapNumbers = new List<int>(Enumerable.Range(0, data.Length)
            .Select(i => random.Next(i, data.Length)));
        for (int i = data.Length - 1; i >= 0; i--)
        {
            byte temp = data[i];
            data[i] = data[swapNumbers[i]];
            data[swapNumbers[i]] = temp;
        }
    }
