        private string executeProcessSO(ProcessStartInfo myProcessStartInfo, out string standardOutput, out string standardError)
        {
            string rslt = "Failed";
            int exitCode = -1;
            using (var process = new Process())
            {
                process.StartInfo = myProcessStartInfo;
                process.Start();
                using (Task<string> outputReader = Task.Factory.StartNew((Func<object, string>)ReadStream, process.StandardOutput))
                using (Task<string> errorReader = Task.Factory.StartNew((Func<object, string>)ReadStream, process.StandardError))
                {
                    process.WaitForExit(10000);
                    standardError = errorReader.Result;
                    standardOutput = outputReader.Result;
                    try
                    {
                        if (process.HasExited)
                        {
                            exitCode = process.ExitCode;
                            if (exitCode.Equals(0))
                                rslt = "Success";
                        }
                        else
                        {
                            process.Kill();
                            rslt = "Timeout";
                        }
                    }
                    catch (Exception e2)
                    {
                        EventLog.WriteEntry("InstallationService", "Error in process.WaitForExit occured: \n" + e2.Message.ToString(), EventLogEntryType.Error);
                        throw e2;
                    }
                }
            }
            return rslt;
        }
