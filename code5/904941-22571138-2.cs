	private void deleteEmptyDirectories(String path)
	{
		var di = new DirectoryInfo(path);
		// get all sub directories and visit each one
		foreach (var d in di.GetDirectories())
		{
			deleteEmptyDirectories(d.FullName);
		}
		// if we are at end of the directory tree
		// look if there are files and directories left
		if (di.GetFiles().Count() == 0 && di.GetDirectories().Count() == 0)
		{
			// if not, delete the directory
			di.Delete();
		}
	}
