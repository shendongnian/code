    void StartNewProcess(string processName, string parameters, string startDir)
    {
       var proc = new Process();
       var args = new ProcessStartInfo(processName);
       args.Arguments = parameters;
       args.WorkingDirectory = startDir;
       args.CreateNoWindow = true;
       args.UseShellExecute = false;
       args.RedirectStandardOutput = true;
       args.RedirectStandardError = true;
       proc = Process.Start(args);
       proc.ErrorDataReceived += p_DataReceived;
       proc.OutputDataReceived += p_DataReceived;
       proc.BeginErrorReadLine();
       proc.BeginOutputReadLine();
       proc.WaitForExit();
    }
