        public static string ExecuteProcess(string FilePath, string Args, string Input, string WorkingDir, int WaitTime = 0, Dictionary<string, string> EnviroVariables = null, bool Trace = false, bool ThrowError = true, int ValidExitCode = 0, Action<string, string> OutputChangedCallback = null)
        {
            var processInfo =
                "FilePath: " + FilePath + "\n" +
                (WaitTime > 0 ? "WaitTime: " + WaitTime.ToString() + " ms\n" : "") +
                (!string.IsNullOrEmpty(Args) ? "Args: " + Args + "\n" : "") +
                (!string.IsNullOrEmpty(Input) ? "Input: " + Input + "\n" : "") +
                (!string.IsNullOrEmpty(WorkingDir) ? "WorkingDir: " + WorkingDir + "\n" : "") +
                (EnviroVariables != null && EnviroVariables.Count > 0 ? "Environment Variables: " + string.Join(", ", EnviroVariables.Select(a => a.Key + "=" + a.Value)) + "\n" : "");
            
            string outputFile = "";
            if (OutputChangedCallback != null)
            {
                outputFile = Path.GetTempFileName();
                Args = "/C \"\"" + FilePath + "\" " + Args + "\" >" + outputFile;
                FilePath = "cmd.exe";
            }
            var startInfo = (string.IsNullOrEmpty(Args))
                ? new ProcessStartInfo(FilePath)
                : new ProcessStartInfo(FilePath, Args);
            if (!string.IsNullOrEmpty(WorkingDir))
                startInfo.WorkingDirectory = WorkingDir;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            if (OutputChangedCallback == null)
            {
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
            }
            else
            {
                startInfo.RedirectStandardOutput = false;
                startInfo.RedirectStandardError = false;
            }
            
            if (!string.IsNullOrEmpty(Input))
                startInfo.RedirectStandardInput = true;
            if (EnviroVariables != null)
                foreach (KeyValuePair<String, String> entry in EnviroVariables)
                    startInfo.EnvironmentVariables.Add(entry.Key, entry.Value);
            var process = new Process();
            process.StartInfo = startInfo;
            if (process.Start())
            {
                if (Trace)
                    Log.Debug("Running external process with the following parameters:\n" + processInfo);
                try
                {
                    if (!string.IsNullOrEmpty(Input))
                    {
                        process.StandardInput.Write(Input);
                        process.StandardInput.Close();
                    }
                    var standardError = "";
                    var standardOutput = "";
                    int exitCode = 0;
                    Thread errorReadThread;
                    Thread outputReadThread;
                    if (OutputChangedCallback == null)
                    {
                        errorReadThread = new Thread(new ThreadStart(() => { standardError = process.StandardError.ReadToEnd(); }));
                        outputReadThread = new Thread(new ThreadStart(() => { standardOutput = process.StandardOutput.ReadToEnd(); }));
                    }
                    else
                    {
                        errorReadThread = new Thread(new ThreadStart(() => { }));
                        outputReadThread = new Thread(new ThreadStart(() =>
                        {
                            long len = 0;
                            while (!process.HasExited)
                            {
                                if (File.Exists(outputFile))
                                {
                                    var info = new FileInfo(outputFile);
                                    if (info.Length != len)
                                    {
                                        var content = new StreamReader(File.Open(outputFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)).ReadToEnd();
                                        var newContent = content.Substring((int)len, (int)(info.Length - len));
                                        len = info.Length;
                                        OutputChangedCallback.Invoke(content, newContent);
                                    }
                                }
                                Thread.Sleep(10);
                            }
                        }));
                    }
                    errorReadThread.Start();
                    outputReadThread.Start();
                    var sw = Stopwatch.StartNew();
                    bool timedOut = false;
                    try
                    {
                        while (errorReadThread.IsAlive || outputReadThread.IsAlive)
                        {
                            Thread.Sleep(50);
                            if (WaitTime > 0 && sw.ElapsedMilliseconds > WaitTime)
                            {
                                if (errorReadThread.IsAlive) errorReadThread.Abort();
                                if (outputReadThread.IsAlive) outputReadThread.Abort();
                                timedOut = true;
                                break;
                            }
                        }
                        if (!process.HasExited)
                            process.Kill();
                        if (timedOut)
                            throw new TimeoutException("Timeout occurred during execution of an external process.\n" + processInfo + "Standard Output: " + standardOutput + "\nStandard Error: " + standardError);
                        exitCode = process.ExitCode;
                    }
                    finally
                    {
                        sw.Stop();
                        process.Close();
                        process.Dispose();
                    }
                    if (ThrowError && exitCode != ValidExitCode)
                        throw new Exception("An error was returned from the execution of an external process.\n" + processInfo + "Exit Code: " + exitCode + "\nStandard Output: " + standardOutput + "\nStandard Error: " + standardError);
                    if (Trace)
                        Log.Debug("Process Exited with the following values:\nExit Code: {0}\nStandard Output: {1}\nStandard Error: {2}", exitCode, standardOutput, standardError);
                    return standardOutput;
                }
                finally
                {
                    FileUtilities.AttemptToDeleteFiles(new string[] { outputFile });
                }
            }
            else
                throw new Exception("The process failed to start.\n" + processInfo);
        }
