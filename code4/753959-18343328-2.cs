    int big = 500;
    String s;
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < 100; ++i)
    {
        sb.Append("cat mouse");
    }
    s = sb.ToString();
            
    Stopwatch sw = new Stopwatch();
    sw.Start();
    for (int i = 0; i < big; ++i)
    { 
        s = s.Replace("cat", "moo"); 
        s = s.Replace("moo", "cat"); 
    }
    sw.Stop(); Trace.WriteLine(sw.ElapsedMilliseconds); sw.Reset(); sw.Start();
    for (int i = 0; i < big; ++i)
    {
        sb.Replace("cat", "moo");
        sb.Replace("moo", "cat");
    }
    sw.Stop(); Trace.WriteLine(sw.ElapsedMilliseconds); sw.Reset(); sw.Start();
    for (int i = 0; i < big; ++i)
    {
        s = s.Replace("cat", "mooo");
        s = s.Replace("mooo", "cat");
    }
    sw.Stop(); Trace.WriteLine(sw.ElapsedMilliseconds); sw.Reset(); sw.Start();
    for (int i = 0; i < big; ++i)
    {
        sb.Replace("cat", "mooo");
        sb.Replace("mooo", "cat");
    }
    sw.Stop(); Trace.WriteLine(sw.ElapsedMilliseconds);
