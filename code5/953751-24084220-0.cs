    public static string ProcessScript(string command, string arguments)
    {
        Process proc = new Process();
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.RedirectStandardError = true;
        proc.StartInfo.FileName = command;
        proc.StartInfo.Arguments = arguments;
        proc.Start();
        var output = proc.StandardOutput.ReadToEndAsync();
        var error = proc.StandardError.ReadToEndAsync();
        proc.WaitForExit();
        proc.Close();
        var errorContent = error.Result;
        return output.Result;
    }
