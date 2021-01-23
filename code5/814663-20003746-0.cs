    private void KillFolders()
    {
        DateTime to_date = DateTime.Now.AddDays(-1);
        List<string> paths = Directory.EnumerateDirectories(@"C:\MotionWise\Catalogue\" + Shared.ActiveMac, "*", SearchOption.AllDirectories)
            .Where(path =>
            {
                DateTime lastWriteTime = File.GetLastWriteTime(path);
                return lastWriteTime <= to_date;
            })
            .ToList();
    		
    	foreach (var path in paths))
    	{
    		cleanDirs(path);
    	}
    }
    
    private static void cleanDirs(string startLocation)
    {
    	foreach (var directory in Directory.GetDirectories(startLocation))
    	{
    		cleanDirs(directory);
    		if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0)
    		{
    			Directory.Delete(directory, false);
    		}
    	}
    }
