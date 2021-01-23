    foreach(DictionaryEntry e in System.Environment.GetEnvironmentVariables())
    {
        Console.WriteLine(e.Key  + ":" + e.Value);
    }
    var compName = System.Environment.GetEnvironmentVariables()["COMPUTERNAME"];
