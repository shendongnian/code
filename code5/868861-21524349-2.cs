    System.Diagnostics.Process process = new System.Diagnostics.Process();
	System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("process file");
	startInfo.RedirectStandardOutput = true;
	process.StartInfo = startInfo;
	process.OutputDataReceived += process_OutputDataReceived;
    ...
        
    private void process_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
    {
       if (!string.IsNullOrEmpty(e.Data))
       {
         ...
       }
    }
