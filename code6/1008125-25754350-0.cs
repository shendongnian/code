    var sw = new Stopwatch();
    var initial= Enumerable.Range(1, 400000).Select(i => i.ToString()).ToList();
    sw.Start();
    var set = new HashSet<object>(initial);
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
    var random = new Random();
    var additional = Enumerable.Range(1, 10000).Select(i => random.Next(1000000).ToString()).ToList();
    sw.Restart();
    foreach (var item in additional)
    {
        set.Add(item);
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
