    List<string> results = new List<string>(myTasks.Count);
    Parallel.ForEach(myTasks, t =>
    {
        string result = t.DoSomethingInBackground();
        lock (results)
        {
            results.Add(result);
        }
    });
    Console.Write("All tasks Completed. Now we can do further processing");
