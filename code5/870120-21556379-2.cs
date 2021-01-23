    string myAppName = "YourAppName";
    DateTime startTime = DateTime.Now;
    int newProcessId = 0;
    List<int> runningProcessIds = new List<int>();
    
    //find all the running processes and record their Ids
    foreach (void proc_loopVariable in Process.GetProcessesByName(myAppName)) {
    	proc = proc_loopVariable;
    	runningProcessIds.Add(proc.Id);
    }
    
    //start the new process
    Process.Start(location);
    
    //wait for the new application to be started
    while (!(Process.GetProcessesByName(myAppName).Count != runningProcessIds.Count)) {
    	//timeout if we have not seen the application start
    	if ((DateTime.Now - startTime).TotalSeconds > 30)
    		break; 
    }
    
    //loop through all the running processes again to find the id of the one that has just started
    foreach (void proc_loopVariable in Process.GetProcessesByName(myAppName)) {
    	proc = proc_loopVariable;
    	if (!runningProcessIds.Contains(proc.Id)) {
    		newProcessId = proc.Id;
    		break; 
    	}
    }
    
    //wait for the application to finish
    Process.GetProcessById(newProcessId).WaitForExit();
    
    Debug.WriteLine("Finished");
