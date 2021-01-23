    private Task copyTargetFiles()
    {
        Task T = new Task(() =>
        {
                string backupPath = Path.Combine(_tempDirectory, "Backup\\Files");
                Directory.CreateDirectory(backupPath);
    
                string sourceFolder = Shared.GetRegistryKey("Folder");
                Infrastructure.Shared.CopyDirectory(sourceFolder, backupPath);
        });
        T.Start(TaskScheduler.Default); //jumps back to the default, unrestricted scheduler context for the file copying
        return T;
    }
