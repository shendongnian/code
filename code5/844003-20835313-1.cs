    public static void LaunchApplication(string runCommand, string commandArguments, string workingDir, string informMessage, Action<string> redirectOutput, Action<string> redirectError)
    {
        try
        {
            Process applicationProcess = new Process();
            applicationProcess.StartInfo.FileName = runCommand;
            applicationProcess.StartInfo.WorkingDirectory = workingDir;
            applicationProcess.StartInfo.Arguments = commandArguments;
            applicationProcess.StartInfo.UseShellExecute = false;
            applicationProcess.EnableRaisingEvents = true;
            applicationProcess.StartInfo.CreateNoWindow = true;
            if (redirectOutput != null)
                applicationProcess.OutputDataReceived += (s, data) => redirectOutput(data.Data);
            if (redirectError != null)
                applicationProcess.ErrorDataReceived += (sErr, errData) => redirectError(errData.Data);
            GeneralUtils.WriteHeadlineToConsole(informMessage);
            applicationProcess.Start();
            if (redirectOutput != null)
                applicationProcess.BeginOutputReadLine();
            if (redirectError != null)
                applicationProcess.BeginErrorReadLine();
            applicationProcess.WaitForExit();
            GeneralUtils.WriteHeadlineToConsole("Finished " + informMessage);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }
