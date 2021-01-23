        public void InvokeProcess(WiresharkProcesses process, string args)
        {
            Task.Factory.StartNew(() =>
            {
                string processToInvoke = null;
                ProcessStartInfo startInfo = new ProcessStartInfo();
                using (Process pros = new Process())
                {
                    startInfo.FileName = processToInvoke;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.RedirectStandardError = true;
                    startInfo.RedirectStandardInput = true;
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = true;
                    startInfo.Arguments = args;
                    pros.StartInfo = startInfo;
                    //pros.EnableRaisingEvents = true;
                    pros.Start();
                    pros.WaitForExit();
                }
                // Copy file
                // Delete file
            });
        }
