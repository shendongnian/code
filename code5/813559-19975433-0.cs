    // Get the list
    var result = SystemCore.Instance.IronportServerStatusDict[host.Host];
    
    if (result.Count >= 10)
    {
        result.RemoveAt(0);
    }
    
    result.Add(logData);
    
    Console.WriteLine(SystemCore.Instance.IronportServerStatusDict[host.Host][0]);
