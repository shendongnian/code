         foreach (void ie_loopVariable in GetCurrentUserIEProcesses()) {
        	ie = ie_loopVariable;
        	//Do some verification here to find your internet explorer using title, handle etc.
        	if (ie.MainWindowTitle.ToLower.Contains("abc")) {
        		ie.Kill();
        	}
        
        }        
  
    //Returns all the Internet Explorer processes of current logged in user
        private List<Process> GetCurrentUserIEProcesses()
        {
        	dynamic currentSessionID = Process.GetCurrentProcess.SessionId;
        	dynamic myAllIEProcess = (from itm in Process.GetProcessesByName("iexplore")where itm.SessionId == currentSessionID).ToList;
        	return myAllIEProcess;
        }
