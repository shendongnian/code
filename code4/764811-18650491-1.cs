    Process exe = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.ToLower().Trim().StartsWith("conquer"));
    if(exe != null)
    {
    	exe.WaitForExit();
    	exe.refresh();
    	if(exe.HasExited)
    	{
    		Application.Exit();
    		Enviroment.Exit(0);
    	}
    }
    else
    {
    	//Conquer process has already exited or was not running.
    }
