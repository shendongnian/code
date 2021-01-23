    private Process formatProc;
    
    Private void DoFormat(string driveLetter) 
    	this.formatProc = new Process
    	{
            StartInfo =
                {
                    UseShellExecute = false,
                    FileName = "format.com",
                    Arguments = string.Format("/FS:FAT {0}: /V: /Q", driveLetter),
    				RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                },
            EnableRaisingEvents = true
        };
    
        this.formatProc.OutputDataReceived += this.ProcOutputDataReceivedHandler;
        this.formatProc.ErrorDataReceived += this.ProcErrorDataReceivedHandler;
        this.formatProc.Exited += this.ProcExitedHandler;
    
        this.formatProc.Start();
        this.formatProc.BeginOutputReadLine();
        this.formatProc.BeginErrorReadLine();
    }
    
    private void ProcOutputDataReceivedHandler(object sendingProcess, DataReceivedEventArgs e)
    {
    	if (string.IsNullOrEmpty(e.Data))
    	{
    		MessageBox.Show(e.Data);
    	}
    }
    
    private void ProcErrorDataReceivedHandler(object sendingProcess, DataReceivedEventArgs e)
    {
    	if (string.IsNullOrEmpty(e.Data))
    	{
    		MessageBox.Show(e.Data);
    	}
    }
    
    private void ProcExitedHandler(object sender, EventArgs e)
    {
    	var exitCode = this.formatProc.ExitCode;
    	var message = string.Empty;
    	switch (exitCode)
    	{
    		case 0: 
    			message = "Format done.";
    			break;
    		case 1:
    			message = "Format failed. Incorrect parameters were supplied.";
    			break;
    		case 4:
    			message = "Format failed. A fatal error occurred.";
    			break;
    		case 5:
    			message = "Format ended by user.";
    			break;
    		default:
    			message = "Format failed. ExitCode = " + this.formatProc.ExitCode;
    			break;
    	}
    
    	this.formatProc.Dispose();
    	MessageBox.Show(message);
    }
