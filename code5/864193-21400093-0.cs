    var tasks=new List<Task>();
    foreach (var File in ServerFiles)
    {
        string sFileName = File.Uri.LocalPath.ToString();
        // some internal logic and initialization 
        Task downloadTask = oBlob.DownloadToStreamAsync(fileStream);
    tasks.Add(downloadTask);
        sFiles += sFileName.Replace("/" + Container + "/", "") + ",";
    }
    Task.WaitAll(tasks);
