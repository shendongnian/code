    int tc2 = Environment.TickCount;
    
    for (int i = 0; i < 200; i++)
    {
        byte[] a = ApplyLookupTableToBufferV2(lt, ib);
    }
    
    tc2 = Environment.TickCount - tc2;
    
    Console.WriteLine("V2: " + tc2.ToString() + "ms");
