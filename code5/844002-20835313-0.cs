    public static void LaunchApplication(string runCommand, string commandArguments, string workingDir, string informMessage,
            Action<string> rcvData )
        {
            try
            {
                var applicationProcess = new Process();
                applicationProcess.StartInfo.FileName = runCommand;
                applicationProcess.StartInfo.WorkingDirectory = workingDir;
                applicationProcess.StartInfo.Arguments = commandArguments;
                applicationProcess.StartInfo.UseShellExecute = false;
                applicationProcess.StartInfo.RedirectStandardOutput = true;
                applicationProcess.EnableRaisingEvents = true;
                WriteHeadlineToConsole(informMessage);
                if (rcvData != null)
                    applicationProcess.OutputDataReceived += (s, data) => rcvData(data.Data);
                applicationProcess.Start();
                applicationProcess.BeginOutputReadLine();
                applicationProcess.WaitForExit(); // it's much better then while loop
                WriteHeadlineToConsole("Finished " + informMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
