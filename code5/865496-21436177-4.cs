    Random r = new Random();
    int a = r.Next();
    int b = r.Next();
    int c = 0;
    Stopwatch sw = new Stopwatch();
    
    sw.Start();
    for (int i = 0; i < int.MaxValue; i++)
    {
        c += a & b;
    }
    sw.Stop();
    Console.WriteLine("AND operator: {0} ticks", sw.Elapsed.Ticks);
    Console.WriteLine("Result: {0}", c);
    c = 0;
    // The above is just to make sure that the optimizer does not optimize the loop away,
    // as pointed out by johnnycrash in the comments.
    sw.Restart();
    for (int i = 0; i < int.MaxValue; i++)
    {
        c += a | b;
    }
    sw.Stop();
    Console.WriteLine("OR operator: {0} ticks", sw.Elapsed.Ticks);
    Console.WriteLine("Result: {0}", c);
    c = 0;
    for (int i = 0; i < int.MaxValue; i++)
    {
        c += a ^ b;
    }
    sw.Stop();
    Console.WriteLine("XOR operator: {0} ticks", sw.Elapsed.Ticks);
    Console.WriteLine("Result: {0}", c);
    c = 0;
    for (int i = 0; i < int.MaxValue; i++)
    {
        c += ~a;
    }
    sw.Stop();
    Console.WriteLine("NOT operator: {0} ticks", sw.Elapsed.Ticks);
    Console.WriteLine("Result: {0}", c);
    c = 0;
    for (int i = 0; i < int.MaxValue; i++)
    {
        c += a << 1;
    }
    sw.Stop();
    Console.WriteLine("Left shift operator: {0} ticks", sw.Elapsed.Ticks);
    Console.WriteLine("Result: {0}", c);
    c = 0;
    for (int i = 0; i < int.MaxValue; i++)
    {
        c += a >> 1;
    }
    sw.Stop();
    Console.WriteLine("Right shift operator: {0} ticks", sw.Elapsed.Ticks);
    Console.WriteLine("Result: {0}", c);
