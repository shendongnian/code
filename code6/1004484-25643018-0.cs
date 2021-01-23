    Process []GetPArry = Process.GetProcesses();
    foreach(Process testProcess in GetPArry)  
    {
        string ProcessName = testProcess .ProcessName;              
        ProcessName  = ProcessName .ToLower();
        if (ProcessName.CompareTo("winword") == 0 && testProcess.SessionId == <SessionID>)
        {
            testProcess.Kill();
        }
    }
