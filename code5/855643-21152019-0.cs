    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    ushort[] bgImg = GenerateRandomBuffer(327680);
    for (int i = 0; i < 1000; i++)
    {
        Buffer = GenerateRandomBuffer(327680);                
        sw.Start();
        SubtractBackgroundFromBuffer(bgImg);
        sw.Stop();
    }
    Console.WriteLine("SubtractBackgroundFromBuffer(ms): " + sw.Elapsed.TotalMilliseconds.ToString("N2"));
    
    public static ushort[] GenerateRandomBuffer(int size)
    {
        ushort[] buffer = new ushort[327680];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            buffer[i] = (ushort)random.Next(ushort.MinValue, ushort.MaxValue);
        }
        return buffer;
    }
