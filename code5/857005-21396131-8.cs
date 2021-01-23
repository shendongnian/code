    /// <summary>
    /// static process ID value
    /// </summary>
    static int? processID = null;
    
    public void startProcess()
    {
        //check if the processID has a value and if the process ID is active
        if (processID.HasValue && Process.GetProcessById(processID.Value) != null)
            return;
    
        //start a new process
        var process = new Process();
        var processStartInfo = new ProcessStartInfo(@"C:\myProg.exe");
        processStartInfo.CreateNoWindow = true;
        processStartInfo.UseShellExecute = false;
        process.StartInfo = processStartInfo;
        process.Start();
        //set the process id
        processID = process.Id;
    }
