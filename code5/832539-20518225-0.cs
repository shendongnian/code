    private void OnShow()
    {
    	var target = Process.GetProcessesByName("MiniLauncher.exe").FirstOrDefault();
    
    	if (target != null)
    	{
    		// any other checks that this is indeed the process you're looking for
    		target.Close();
    	}
    
    }
