    public class ProcessStarter
        {
            public static OutputEventArgs execAsync(string exe, string arguments)
            {
                OutputEventArgs oea = new OutputEventArgs();
                try
                {
                    using (Process myProcess = new Process())
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.RedirectStandardOutput = true;
                        startInfo.RedirectStandardError = true;
                        startInfo.UseShellExecute = false;
                        startInfo.CreateNoWindow = true;
                        startInfo.FileName = exe;
                        startInfo.Arguments = arguments;
                        myProcess.StartInfo = startInfo;
                        myProcess.Start();
                        oea.Data = myProcess.StandardOutput.ReadToEnd();
                        myProcess.WaitForExit();
                        oea.exitCode = myProcess.ExitCode;
                    }
                }catch(Exception e)
                {
                    oea.Data = e.Message;
                    oea.ExceptionHappened();
                }
                return oea;
            }
        }
        public class OutputEventArgs
        {
            public int exitCode { get; set; }
            public OutputEventArgs() { Error = false; }
            public string Data { get; set; }
            public bool Error { get; set; }
            public void ExceptionHappened()
            {
                exitCode = int.MinValue;
                Error = true;
                Data = string.Empty;
            }
        }
