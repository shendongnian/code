    static void Main(string[] args)
    {
        float f = 2.1f;
        byte[] bytes = System.BitConverter.GetBytes(f);
        BitArray array = new BitArray(bytes);
        array.Set(20, true, -5.12f, 5.12f);
    }
