    var cache = new ConcurrentDictionary<long, long>();    
    obs2.Subscribe(x => cache[x.Item1] = x.Item2);    
    var results = obs1.Select(x => new {
        obs1 = x.Item2,
        cache.ContainsKey(x.Item1) ? cache[x.Item1] : 0
    });
