    static void ExecuteCommand(string command)
    {
        int exitCode;
        ProcessStartInfo processInfo;
        Process process;
        processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
        processInfo.CreateNoWindow = true;
        processInfo.UseShellExecute = false;
        process = Process.Start(processInfo);
        process.WaitForExit();
        exitCode = process.ExitCode;
        process.Close();
    }
