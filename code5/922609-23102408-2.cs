    public void ExecuteCommand(string command)
    {
        int ExitCode;
        ProcessStartInfo ProcessInfo;
        Process process;
        string sBatchFilePath = textBox2.Text;  //batch file Path
    
        ProcessInfo = new ProcessStartInfo(sBatchFilePath, command);
        ProcessInfo.CreateNoWindow = false;
        ProcessInfo.UseShellExecute = false;
        ProcessInfo.WorkingDirectory = Path.GetDirectoryName(sBatchFilePath);
        // *** Redirect the output ***
        ProcessInfo.RedirectStandardError = true;
        ProcessInfo.RedirectStandardOutput = true;
        process = Process.Start(ProcessInfo);
        process.WaitForExit();
        // *** Read the streams ***
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        ExitCode = process.ExitCode;
    }
