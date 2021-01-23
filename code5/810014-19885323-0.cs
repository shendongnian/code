    private void getfiles() {
      List<List<FileInfo>> fileList = new List<List<FileInfo>>();
      for (int i = 0; i < BackgroundWorkerConfiguration.urlsDirectories.Count; i++) {
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(BackgroundWorkerConfiguration.urlsDirectories[i]);
        fileList.AddRange(di.GetFiles("*.*", System.IO.SearchOption.AllDirectories)
                            .Where(x => x.Length > 0));
      }
      file_array = fileList.OrderBy(x => x.CreationTime)
                           .GroupBy(x => x.DirectoryName)
                           .Select(g => g.Select(x => x.FullName).ToList())
                           .ToArray();
      timer1.Enabled = true;
    }
