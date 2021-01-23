    public static List<string> getFiles()
    {
      List<string> listReturn = new List<string>();
      string[] filePaths = Directory.GetFiles(backupFolder);
      return filePaths.ToList();
    }
