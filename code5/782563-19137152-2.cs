    static void GetFiles(string dir)
    {
        string[] filetypes = new string[] { "3gp", "avi", "dat", "mp4", "wmv", 
                                                         "mov", "mpg", "flv",  }
        foreach(string ft in filetypes)
        {
    	   foreach (string file in Directory.GetFiles(dir, string.Format("*.{0}", ft),
                                                  SearchOption.TopDirectoryOnly)))
     	   { 
    	         files.Add(new FileInfo(file));
    	   }
        }
    	foreach (string subDir in Directory.GetDirectories(dir))
    	{
    		try
    		{
    			GetFiles(subDir);
    		}
    		catch
    		{
    		}
    	}
    }
