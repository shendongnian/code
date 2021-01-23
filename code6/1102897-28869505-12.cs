    void StartNewProcess(string processName, string parameters, string startDir)
    {
        var proc = new Process();
        var args = new ProcessStartInfo 
        { 
            FileName = processName,
            Arguments = parameters,
            WorkingDirectory = startDir,
            CreateNoWindow = true,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        proc = Process.Start(args);
        proc.ErrorDataReceived += p_DataReceived;
        proc.OutputDataReceived += p_DataReceived;
        proc.BeginErrorReadLine();
        proc.BeginOutputReadLine();
        proc.WaitForExit();
    }
