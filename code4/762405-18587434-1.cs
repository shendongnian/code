    List<object> SomeList = new List<object>();
    Stopwatch sw = new Stopwatch();
    sw.Start();
    for (var i = 0; i < 100000; i++)
        SomeList.Insert(0, String.Empty);
    sw.Stop();
    Console.WriteLine(sw.Elapsed.TotalMilliseconds);
    sw.Reset();
    SomeList = new List<object>();
    sw.Start();
    for (var i = 0; i < 100000; i++)
        SomeList.Add(String.Empty);
    sw.Stop();
    Console.WriteLine(sw.Elapsed.TotalMilliseconds);
