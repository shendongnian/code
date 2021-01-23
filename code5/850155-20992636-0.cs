    using System.Diagnostics;
    
    private void runCom(string command)
    {
        ProcessStartInfo procInfo = new ProcessStartInfo("cmd", "/c" + command);
        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true;
        Process proc = new Process();
        proc.StartInfo = startInfo;
        proc.Start();
        proc.WaitForExit();
    }
