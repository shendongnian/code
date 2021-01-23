    public void ExecuteCommand(string sBatchFile, string command)
    {
        int ExitCode;
        ProcessStartInfo ProcessInfo;
        Process process;
        string sBatchFilePath = textBox2.Text;  //batch file Path
    
        ProcessInfo = new ProcessStartInfo(sBatchFile, command);
        ProcessInfo.CreateNoWindow = false;
        ProcessInfo.UseShellExecute = false;
        ProcessInfo.WorkingDirectory = Path.GetDirectoryName(sBatchFile);
        // *** Redirect the output ***
        ProcessInfo.RedirectStandardError = true;
        ProcessInfo.RedirectStandardOutput = true;
        process = Process.Start(ProcessInfo);
        process.WaitForExit();
        // *** Read the streams ***
        string sInput = process.StardardInput.ReadToEnd();
        string sOutput = process.StandardOutput.ReadToEnd();
        string sError = process.StandardError.ReadToEnd();
        ExitCode = process.ExitCode;
    }
