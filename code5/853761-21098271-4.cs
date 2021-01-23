    int tc1 = Environment.TickCount;
    
    for (int i = 0; i < 200; i++)
    {
        byte[] a = ApplyLookupTableToBufferV1(lt, ib);
    }
    
    tc1 = Environment.TickCount - tc1;
    
    Console.WriteLine("V1: " + tc1.ToString() + "ms");
