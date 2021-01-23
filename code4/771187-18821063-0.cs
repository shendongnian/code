    private ProcessStartInfo psi;
    private Process cmd;
    private delegate void InvokeWithString(string text);
    public void StartBurning()
    {
	string filePath = "Your Exe path";
	psi = new ProcessStartInfo(filePath);
	System.Text.Encoding systemencoding =     System.Text.Encoding.GetEncoding(Globalization.CultureInfo.CurrentUICulture.TextInfo.OEMCodePage);
	var _with1 = psi;
	_with1.Arguments = "Your Input String";
	_with1.UseShellExecute = false;
	// Required for redirection
	_with1.RedirectStandardError = true;
	_with1.RedirectStandardOutput = true;
	_with1.RedirectStandardInput = true;
	_with1.CreateNoWindow = false;
	_with1.StandardOutputEncoding = systemencoding;
	// Use OEM encoding for console applications
	_with1.StandardErrorEncoding = systemencoding;
	// EnableraisingEvents is required for Exited event
	cmd = new Process {
		StartInfo = psi,
		EnableRaisingEvents = true
	};
	cmd.ErrorDataReceived += Async_Data_Received;
	cmd.OutputDataReceived += Async_Data_Received;
	cmd.Exited += processExited;
	cmd.Start();
	myProcList.Add(cmd.Id);
	cmd.BeginOutputReadLine();
	cmd.BeginErrorReadLine();
      }
      private void Async_Data_Received(object sender, DataReceivedEventArgs e)
      {
	this.Invoke(new InvokeWithString(Sync_Output), e.Data);
       }
      private void Sync_Output1(string text)
       {
     //This Textbox needs to place at the GUI to check the output Log from your exe. 
	txtLog.AppendText(text + Environment.NewLine);
      }
      private void processExited(object sender, EventArgs e)
      {
	 this.BeginInvoke(new Action(() => { MessageBox.Show("The burn process   Terminated.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }));
       }
