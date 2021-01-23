    Process p = new Process();
    p.StartInfo = psi;
    p.OutputDataReceived += OutputHandler;
    p.Start();
    
    p.BeginOutputReadLine();
    
    p.WaitForExit();
    p.OutputDataReceived -= OutputHandler;
    private void OutputHandler(object sender, DataReceivedEventArgs outLine)
    {
        txtOutput.Text += outLine.Data;
    }
