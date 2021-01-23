    string dir = Path.GetDirectoryName(scriptPath);                       
    ICollection<string> paths = engine.GetSearchPaths();
    
    if (!string.IsNullOrEmptydir))
    {
        paths.Add(dir);
    }
    else
    {
        paths.Add(Environment.CurrentDirectory);
    }
    engine.SetSearchPaths(paths);
