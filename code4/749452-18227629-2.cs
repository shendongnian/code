    List<string> results = new List<string>(myTasks.Count);
    Parallel.ForEach(myTasks, t =>
    {
        string result = t.DoSomethingInBackground();
        lock (results)
        { // lock the list to avoid race conditions
            results.Add(result);
        }
    });
