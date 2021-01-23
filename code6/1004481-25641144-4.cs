    Process []GetPArry = Process.GetProcesses();
    foreach(Process testProcess in GetPArry)  
    {
        if (testProcess.Id == pid)
        {
            testProcess.Kill();
            break;
        }
    }
