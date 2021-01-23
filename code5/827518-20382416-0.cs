    Task T = Task.Run(() =>
    {
            string backupPath = Path.Combine(_tempDirectory, "Backup\\Files");
            Directory.CreateDirectory(backupPath);
            string sourceFolder = Shared.GetRegistryKey("Folder");
            Infrastructure.Shared.CopyDirectory(sourceFolder, backupPath);
    });
