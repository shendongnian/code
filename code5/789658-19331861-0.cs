    var dic = new Dictionary<string, byte[]>();
    for (int i = 0; i < 1000000; i++)
    {
        dic.Add("key" + i, Serialize<string>("some value which is awesome" + i));
    }
    var watch = new Stopwatch();
    watch.Restart();
    Console.WriteLine("start parallel");
    var result = dic.AsParallel().Select(p => Deserialize<string>(p.Value)).ToList();
    var p1 = watch.ElapsedMilliseconds;
    watch.Restart();
    Console.WriteLine("start sequential");
    var result2 = dic.Select(p => Deserialize<string>(p.Value)).ToList();
    var p2 = watch.ElapsedMilliseconds;
