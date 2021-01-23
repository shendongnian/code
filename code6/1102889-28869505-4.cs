    void StartNewProcess(string processName = "cmd.exe", string parameters = "/C dir")
    {
       var p = new Process();
       var args = new ProcessStartInfo(processName);
       args.Arguments = parameters; //Example: Will list all directories/files in C:\
       args.WorkingDirectory = "C:\\";
       args.CreateNoWindow = true;
       args.UseShellExecute = false;
       args.RedirectStandardOutput = true;
       args.RedirectStandardError = true;
       p = Process.Start(args);
       p.ErrorDataReceived += p_DataReceived;
       p.OutputDataReceived += p_DataReceived;
       p.BeginErrorReadLine();
       p.BeginOutputReadLine();
       p.WaitForExit();
    }
