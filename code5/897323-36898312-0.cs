    private static string ExpandEnvironmentVariablesWithSubstitution(string value)
    {
        string result = string.Empty;
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = string.Concat("/c echo ", value),
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true
            }
        };
        process.OutputDataReceived += (s, e) => result = string.IsNullOrWhiteSpace(e.Data) ? result: e.Data;
        process.Start();
        process.BeginOutputReadLine();
        process.WaitForExit();
        process.CancelOutputRead();
        if (!process.HasExited)
            process.Kill();
        return result;
    }
