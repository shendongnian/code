    try // If you have no administrator privilege, try will fire.
    {
    	foreach (Process proc in Process.GetProcessesByName("name process")) // You can get the name by looking in your task manager.
                {
                    proc.Kill();
                }
    }
    catch(Exception ex)
    {
    	// Add error handling
    }
