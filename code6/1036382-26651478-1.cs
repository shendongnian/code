    Stopwatch watch = new Stopwatch();
    watch.Start();
    var ver1 = list.OrderBy(m => m.Value).Skip(1).Take(list.Count - 2).ToList();
    watch.Stop();
    var ver1time = watch.ElapsedMilliseconds;
    watch.Reset();
    watch.Start();
    list.Remove(list.Where(x => x.Value == list.Max(y => y.Value)).First());
    list.Remove(list.Where(x => x.Value == list.Min(y => y.Value)).First());
    watch.Stop();
    var ver2time = watch.ElapsedMilliseconds;
    Console.WriteLine("First method (order by): {0}ms\nSecond method (remove): {1}ms",
    ver1time,ver2time);
