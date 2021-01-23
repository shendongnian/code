    class Script
        {
    
            public string Output
            {
                get
                {
                    return pOutput;
                }
            }
    
            public string Errors
            {
                get
                {
                    return pErrors;
                }
            }
            
            public bool IsRunning
            {
                get
                {
                    return pIsRunning;
                }
            }
            
            private string pOutput = "";
            private string pErrors = "";
            private bool pIsRunning = false;
            
            public delegate void OutputEventHandler(Script sender, string Output, bool IsError);
    
            public delegate void StatusEventHandler(Script sender);
    
            public event OutputEventHandler OutputDataReceived;
            public event OutputEventHandler ErrorDataReceived;
            public event StatusEventHandler Started;
            public event StatusEventHandler Exited;
            
            private Process cmd;
    
            public void StartProcess()
            {
                pIsRunning = true;
                cmd.Start();
                cmd.BeginOutputReadLine();
                cmd.BeginErrorReadLine();
                Started(this);
            }
    
            public void KillProcess()
            {
                if (IsRunning)
                {
                    cmd.Kill();
                }
            }
    
            public void SetupScript()
            {
                cmd = new Process();
                
                //configure Process (but don't start it yet)
            }
    
            private void cmd_Exited(object sender, EventArgs e)
            {
                pIsRunning = false;
                Exited(this);
                //do other stuff
            }
    
            private void cmd_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                OutputDataReceived(this, e.Data + Environment.NewLine, 
                //do stuff
            }
    
            private void cmd_ErrorDataReceived(object sender, DataReceivedEventArgs e)
            {
                ErrorDataReceived(this, e.Data + Environment.NewLine, true);
                //do stuff
            }
        }
