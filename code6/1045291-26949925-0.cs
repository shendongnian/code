    public void CopyFiles(string sourceDir, string targetDir)
    {
        string[] files = Directory.GetFiles(sourceDir);
        foreach (var fileName in files)
        {
            string targetFile = Path.Combine(targetDir, (new FileInfo()).Name);
            if (File.Exists(targetFile) == false)
                File.Copy(fileName, targetFile);
        }
    }
