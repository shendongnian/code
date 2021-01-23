    private Process proc;
    private string procOutput = string.Empty;
    
    private void StartProc()
    {
        this.procOutput = string.Empty;
        this.proc = new Process();
       ...
        this.proc.StartInfo.UseShellExecute = false;
        this.proc.StartInfo.CreateNoWindow = true;
        this.proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        this.proc.EnableRaisingEvents = true;
        this.proc.OutputDataReceived += this.ProcOutputDataReceivedHandler;
        this.proc.Exited += this.ProcExitedHandler;
    
        this.proc.Start();
    
        this.proc.BeginOutputReadLine();
    }
    
    private void ProcOutputDataReceivedHandler(object sendingProcess, DataReceivedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Data))
        {
             this.procOutput += e.Data;
        }
    }
    
    private void ProcExitedHandler(object sender, EventArgs e)
    {
        // Check the exitcode for possible errors happened during execution.
        MessageBox.Show(this.procOutput);
    }
