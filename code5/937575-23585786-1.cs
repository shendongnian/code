    IEnumerable<string> GetAllFiles(string path, string pattern)
    {
        IEnumerable<string> files = null;
        try
        {
            files = Directory.GetFiles(path, pattern);
        }
        catch (UnauthorizedAccessException) { }
        if (files == null) yield break;
        foreach (var fname in files) yield return fname;
                                    
        foreach (var dname in Directory.GetDirectories(path))
        {
            foreach (var fname in GetAllFiles(dname, pattern)) yield return fname;
        }
    }
