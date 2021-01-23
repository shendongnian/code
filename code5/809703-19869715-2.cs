    List<System.IO.FileInfo> fileList = new List<System.IO.FileInfo>();
    for (int i = 0; i < BackgroundWorkerConfiguration.urlsDirectories.Count; i++)
    {
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(BackgroundWorkerConfiguration.urlsDirectories[i]);
        fileList.AddRange(di.GetFiles("*.*", System.IO.SearchOption.AllDirectories).Where(x => x.Length > 0));
    }
