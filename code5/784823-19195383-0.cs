    string[] fileExtensions = new string[] { "thumb-*.jpg", "thumb-*.png", "thumb-*.bmp", "thumb-*.gif" };
    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@"c:\");
    List<System.IO.FileInfo> filesFound = new List<System.IO.FileInfo>();
    foreach (String fileExt in fileExtensions)
    {
        filesFound.AddRange(di.EnumerateFiles(fileExt, System.IO.SearchOption.AllDirectories));
    }
