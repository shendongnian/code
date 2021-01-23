    public List<string> DoStuffInParallel(IWorkerFactory factory)
    {
        var list = new System.Collections.Concurrent.ConcurrentBag<string>();
        Parallel.For(0, 10, i => 
        { 
            list.Add(factory.Create().GetString());
        });
        return list.ToList();
    }
