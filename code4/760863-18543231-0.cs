        private void RunWithOutput(string exe, string parameters, out string result, out int exitCode)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(exe, parameters);
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;
            Process p = new Process();
            p.StartInfo = startInfo;
            p.Start();
            StringBuilder sb = new StringBuilder();
            object locker = new object();
            p.OutputDataReceived += new DataReceivedEventHandler(delegate(object sender, DataReceivedEventArgs args) 
            {
                lock(locker)
                {
                    sb.Append(args.Data);
                }
            } );
            p.ErrorDataReceived += new DataReceivedEventHandler(delegate(object sender, DataReceivedEventArgs args)
            {
                lock (locker)
                {
                    sb.Append(args.Data);
                }
            });
            p.BeginErrorReadLine();
            p.BeginOutputReadLine();
            p.WaitForExit();
            result = sb.ToString();
            exitCode = p.ExitCode;
        }
