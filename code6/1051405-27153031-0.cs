    public void Scan(DirectoryInfo dir = null)
    {
        if (dir == null)
        {
            dir = new DirectoryInfo(System.Environment
                  .GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData));
        }
        try
        {
            var dirs = dir.GetDirectories();
            foreach (var subDir in dirs)
                Scan(subDir);
            var files = dir.GetFiles("*.exe", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
                // check file
        }
        catch(UnauthorizedAccessException)
        {
            // log error
        }
    }
