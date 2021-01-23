	private void deleteEmptyDirectories(String path)
	{
		var di = new DirectoryInfo(path);
		// if directory is empty
		if (di.GetFiles().Count() == 0 && di.GetDirectories().Count() == 0)
		{
			di.Delete(); // it
			// and go one up
			deleteEmptyDirectories(di.Parent.FullName);
		}
		// else stop (recursion) here
	}
