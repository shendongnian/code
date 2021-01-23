    private static string ExecuteCommand(string command, string arguments)
    {
        command = System.Environment.ExpandEnvironmentVariables(command);
        var process = new Process
        {
            StartInfo =
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                FileName = command,
                Arguments = arguments
            }
        };
        process.Start();
        process.WaitForExit();
        return process.StandardOutput.ReadToEnd();
    }
