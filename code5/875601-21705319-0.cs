    var tasks = new List<Task>();
    foreach (var acc in Accounts)
    {
        acc.WebProxy = null;
        Debug.WriteLine("Connecting to {0}.", new object[] { acc.Username });
        tasks.AdD(acc.ConnectToIrc());
    }
    await Task.WhenAll(tasks);
