    Process exe = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.ToLower().Trim().StartsWith("conquer"));
    if(exe == null)
    {
    	exe = new Process();
    	exe.StartInfo.FileName = "conquer.exe"
    	exe.Start();
    
    	exe.WaitForExit();
    	exe.refresh();
    	if(exe.HasExited)
    	{
    		Application.Exit();
    		Enviroment.Exit(0);
    	}
    }
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
