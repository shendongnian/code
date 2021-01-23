    var availableSpace = DriveInfo.GetDrives()
        .First(d => d.Name == @"C:\").AvailableFreeSpace;
    long usedSpace = 0;
    var availableFiles = files
        .TakeWhile(f => (usedSpace += f.Length) < availableSpace);
    foreach (FileInfo file in availableFiles)
    {
        Console.WriteLine(file.Name);
    }
