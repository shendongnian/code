    public static void DeleteDirectory(string targetDir)
    {
        string[] files = Directory.GetFiles(targetDir, "*", SearchOption.AllDirectories);
        foreach (string file in files)
            File.Delete(file);
        new Microsoft.VisualBasic.Devices.Computer().FileSystem.DeleteDirectory(targetDir, DeleteDirectoryOption.DeleteAllContents);
    }
    
    public static void MoveDirectory(string source, string dest)
    {
        new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(source, dest, true);
        DeleteDirectory(source);
    }
