    const int Size = 100000;
    private static void InstanceOverheadTest()
    {
        object[] array = new object[Size];
        long initialMemory = GC.GetTotalMemory(true);
        for (int i = 0; i < Size; i++)
        {
            array[i] = new Node();
        }
        long finalMemory = GC.GetTotalMemory(true);
        GC.KeepAlive(array);
        long total = finalMemory - initialMemory;
        Console.WriteLine("Measured size of each element: {0:0.000} bytes",
                          ((double)total) / Size);
    }
