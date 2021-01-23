                         // Get the current process.
        			Process currentProcess = Process.GetCurrentProcess();
        
        			
        			// Get all instances of Notepad running on the local 
        			// computer.
        			Process [] localByName = Process.GetProcessesByName("notepad");
        
        			
        			// Get all instances of Notepad running on the specifiec 
        			// computer. 
        			// 1. Using the computer alias (do not precede with "\\").
        			Process [] remoteByName = Process.GetProcessesByName("notepad", "myComputer");
        			
        			// 2. Using an IP address to specify the machineName parameter. 
        			Process [] ipByName = Process.GetProcessesByName("notepad", "169.0.0.0");
        			
        			
        			// Get all processes running on the local computer.
        			Process [] localAll = Process.GetProcesses();
        
        			
        			// Get all processes running on the remote computer.
        			Process [] remoteAll = Process.GetProcesses("myComputer");
        
        			
        			// Get a process on the local computer, using the process id.
        			Process localById = Process.GetProcessById(1234);
        
        			
        			// Get a process on a remote computer, using the process id.
        			Process remoteById = Process.GetProcessById(2345,"myComputer");
