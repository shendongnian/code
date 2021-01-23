	// monitor all *.dat files in the d:\temp directory
	var fsw = new FileSystemWatcher("d:\\temp\\", "*.dat");
	// only when they are changed
	fsw.NotifyFilter = NotifyFilters.LastWrite;
	// register to change event
	fsw.Changed += OnChanged;
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
		// for example reload file using File.ReadAllText(e.FullPath);
       Console.WriteLine("File: " +  e.FullPath + " " + e.ChangeType);
    }
