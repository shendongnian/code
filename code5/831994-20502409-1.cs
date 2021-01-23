    var process = Process.GetCurrentProcess();
    using (var dataTarget = DataTarget.AttachToProcess(process.Id, 1000, AttachFlag.Passive))
    {
        string dacLocation = dataTarget.ClrVersions[0].TryGetDacLocation();
        ClrRuntime runtime = dataTarget.CreateRuntime(dacLocation);
        GetStats(runtime);
        List<User> list = new List<User>();
        Enumerable.Range(1, 1000).ToList().ForEach(i => list.Add(new User() { Age = i }));
        Thread.Sleep(10000);
        GetStats(runtime);
    }
