        // Example of ShowOutput and ShowError that will be used in Form1.cs
                //void ShowOutput(object sender, DataReceivedEventArgs e)
                //{
                //    if (e.Data != null)
                //        this.InvokeEx(x => x.listBox1.Items.Add(e.Data));
                //}
        
                //private void ShowError(object sender, DataReceivedEventArgs e)
                //{
                //    if (e.Data != null)
                //        this.InvokeEx(x => x.listBox1.Items.Add(e.Data));
                //}
        
        namespace WindowsFormsApplication1
        {
            public class CaptureConsole : IDisposable
            {
                private string ExecutableName;
                private string[] Parameters;
        
                private Process ConsoleProcess = new Process();
                private bool disposed = false; // from MSDN
        
                private DataReceivedEventHandler OnCaptureOutput;
                private DataReceivedEventHandler OnCaptureError;
        
                public CaptureConsole() { }
        
                public CaptureConsole(string _executableName, string[] _parameters, DataReceivedEventHandler _onCaptureOutput, DataReceivedEventHandler _onCaptureError)
                {
                    this.ExecutableName = _executableName;
                    this.Parameters = _parameters;
                    this.OnCaptureOutput = _onCaptureOutput;
                    this.OnCaptureError = _onCaptureError;
        
                    ProcessStartInfo startInfo = new ProcessStartInfo()
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        FileName = this.ExecutableName
                    };
        
                    // Parsing arguments
                    for (int i = 0; i < this.Parameters.Length; i++)
                    {
                        if (i == 0)
                            startInfo.Arguments = this.Parameters[0];
                        if (i > 0)
                        {
                            startInfo.Arguments += " ";
                            startInfo.Arguments += this.Parameters[i];
                        }
                    }
        
                    Process process = new Process()
                    {
                        StartInfo = startInfo
                    };
                    process.OutputDataReceived += this.OnCaptureOutput;
                    process.ErrorDataReceived += this.OnCaptureError;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.CreateNoWindow = true;
                    process.EnableRaisingEvents = true;
                    ConsoleProcess = process;
                }
                
                public Process Run(int StartDelay = 250)
                {
                    Thread processThread = new Thread(() =>
                    {
                        ConsoleProcess.Start();
                        ConsoleProcess.BeginOutputReadLine();
                        ConsoleProcess.BeginErrorReadLine();
                    }) { IsBackground = true };
        
                    processThread.Start();
                    Thread.Sleep(StartDelay);
                    return ConsoleProcess;
                }
        
                //Implement IDisposable.
                public void Dispose()
                {
                    Dispose(true);
                    GC.SuppressFinalize(this);
                }
                // from MSDN
                protected virtual void Dispose(bool disposing)
                {
                    if (!disposed)
                    {
                        if (disposing)
                        {
                            // Manual release of managed resources.
                        }
                        // Release unmanaged resources.
                        try
                        {
                            ConsoleProcess.Kill();
                        }
                        catch { }
                        finally
                        {
                            disposed = true;
                        }
                    }
                }
        
                ~CaptureConsole() { Dispose(false); }
            }
        }
