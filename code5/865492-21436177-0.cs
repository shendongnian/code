    Random r = new Random();
    int a = r.Next();
    int b = r.Next();
    int c;
    Stopwatch sw = new Stopwatch();
    
    sw.Start();
    for (int i = 0; i < int.MaxValue; i++)
    {
        c = a & b;
    }
    sw.Stop();
    Console.WriteLine("AND operator: {0} ticks", sw.Elapsed.Ticks);
    sw.Restart();
    for (int i = 0; i < int.MaxValue; i++)
    {
        c = a | b;
    }
    sw.Stop();
    Console.WriteLine("OR operator: {0} ticks", sw.Elapsed.Ticks);
    for (int i = 0; i < int.MaxValue; i++)
    {
        c = a ^ b;
    }
    sw.Stop();
    Console.WriteLine("XOR operator: {0} ticks", sw.Elapsed.Ticks);
    for (int i = 0; i < int.MaxValue; i++)
    {
        c = ~a;
    }
    sw.Stop();
    Console.WriteLine("NOT operator: {0} ticks", sw.Elapsed.Ticks);
    for (int i = 0; i < int.MaxValue; i++)
    {
        c = a << 1;
    }
    sw.Stop();
    Console.WriteLine("Left shift operator: {0} ticks", sw.Elapsed.Ticks);
    for (int i = 0; i < int.MaxValue; i++)
    {
        c = a >> 1;
    }
    sw.Stop();
    Console.WriteLine("Right shift operator: {0} ticks", sw.Elapsed.Ticks);
