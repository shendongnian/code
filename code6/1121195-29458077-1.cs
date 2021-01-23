    string FileDes = string.Empty; //FileDescription
    foreach (Process x in Process.GetProcesses) {
    	if (FileDes == x.MainModule.FileVersionInfo.FileDescription) {
    		x.Kill();
    	}
    }
