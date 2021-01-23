    var l = new SortedList<DateTime, TestObj>();
    var key = new DateTime(1995, 1, 1);
    for (var i = 0; i < 20000; i++)
    {
        var o = new TestObj();
        o.Key = key;
        key = key.AddDays(1);
        l.Add(o.Key, o);
    }
    var sw = new Stopwatch();
    var date1 = new DateTime(1995, 5, 5);
    var date2 = new DateTime(2010, 5, 5);
    sw.Start();
    var between = l.Where(x => x.Key >= date1 && x.Key <= date2).ToArray();
    Console.WriteLine(between.Count());
    sw.Stop();
    Console.WriteLine(sw.Elapsed);
