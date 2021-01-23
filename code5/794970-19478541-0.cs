     Process[] myProcesses;
		// Returns array containing all instances of Notepad.
		myProcesses = Process.GetProcessesByName("Notepad");
		foreach (Process myProcess in myProcesses)
		{
			myProcess.CloseMainWindow();
		}
