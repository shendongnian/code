    string[] systemAFiles = System.IO.Directory.GetFiles("G:\\");
    Dictionary<DateTime, string> filesAndTimes = new Dictionary<DateTime, string>();
    
    foreach (string file in systemAFiles)
    {
        var time = System.IO.File.GetLastWriteTime(file);
        filesAndTimes[time] = file;
    }
