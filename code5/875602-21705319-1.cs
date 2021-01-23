    var tasks = new List<Task>();
    foreach (var acc in Accounts)
    {
        acc.WebProxy = null;
        Debug.WriteLine("Connecting to {0}.", new object[] { acc.Username });
        tasks.Add(acc.ConnectToIrc());
    }
    await Task.WhenAll(tasks);
