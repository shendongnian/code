    var processes = new Dictionary<string,Process>();
    
    foreach (string script in scriptList)
    {
        ProcessStartInfo myProcess = new ProcessStartInfo();
         myProcess.FileName = accoreconsolePath;
         myProcess.Arguments = "/s \"" + script + "\"";
         myProcess.CreateNoWindow = true;
         myWait = Process.Start(myProcess);
    	 processes.Add(script, myWait);
    }
    
    foreach(var script in processes.Keys)
    {
    	Process process = processes[script];
    	
        process.WaitForExit();
        process.Close();
    	
    	File.Delete(script);
    }
