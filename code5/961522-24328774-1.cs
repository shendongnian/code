    public List<string> DoStuffInParallel(IWorkerFactory factory)
    {
        var list = new System.Collections.Concurrent.ConcurrentBag<string>();
        Parallel.For(0, 10, i => 
        { 
            var result = Add(factory.Create().GetString());
            lock(list)
            {
               list.Add(result);
            }
        });
        return list.ToList();
    }
