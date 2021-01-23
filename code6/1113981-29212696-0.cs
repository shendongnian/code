    Process myProcess;
    myProcess = Process.Start("Notepad.exe");
            
            
      if (!myProcess.HasExited)
      {
          // Discard cached information about the process.
            myProcess.Refresh();
          // Print working set to console.
            Console.WriteLine("Physical Memory Usage: " 
                                        + myProcess.WorkingSet.ToString());                   
       }
