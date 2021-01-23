     public class cmdShell
        {
            private Process shellProcess;
    
            public delegate void onDataHandler(cmdShell sender, string e);
            public event onDataHandler onData;
    
            public cmdShell()
            {
                try
                {
                    shellProcess = new Process();
                    ProcessStartInfo si = new ProcessStartInfo("cmd.exe");
                    si.Arguments = "/k";
                    si.RedirectStandardInput = true;
                    si.RedirectStandardOutput = true;
                    si.RedirectStandardError = true;
                    si.UseShellExecute = false;
                    si.CreateNoWindow = true;
                    si.WorkingDirectory = Environment.GetEnvironmentVariable("windir");
                    shellProcess.StartInfo = si;
                    shellProcess.OutputDataReceived += shellProcess_OutputDataReceived;
                    shellProcess.ErrorDataReceived += shellProcess_ErrorDataReceived;
                    shellProcess.Start();
                    shellProcess.BeginErrorReadLine();
                    shellProcess.BeginOutputReadLine();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }
            }
    
            void shellProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
            {
                doOnData(e.Data);
            }
    
            void shellProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                doOnData(e.Data);
            }
    
            private void doOnData(string data)
            {
                if (onData != null) onData(this, data);
            }
    
            public void write(string data)
            {
                try
                {
                    shellProcess.StandardInput.WriteLine(data);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }
            }
        }
