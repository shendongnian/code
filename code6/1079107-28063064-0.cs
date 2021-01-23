    if (File.Exists("try.exe"))
    {
        ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/k " + String.Join(" ", args));
        procStartInfo.RedirectStandardOutput = true;
        procStartInfo.RedirectStandardError = true;
        procStartInfo.UseShellExecute = false;
        procStartInfo.CreateNoWindow = false;
        Process proc = new Process();
        proc.StartInfo = procStartInfo;
        proc.Start();
        proc.WaitForExit();
        
        //At this point the process you started is done.
        if (File.Exists("def")) 
        {
           //do something
        }
    }
