    List<Func<object>> actions = new List<Func<object>>();
    actions.Add(delegate { return (object)(1); });
    actions.Add(delegate { return (object)(1); });
    actions.Add(delegate { return (object)(1); });
    Dictionary<string, object> results = new Dictionary<string,object>();
    Parallel.ForEach(actions,(f)=> {
        lock (results)
        {
            results.Add(Guid.NewGuid().ToString(), f());
        }
    });
