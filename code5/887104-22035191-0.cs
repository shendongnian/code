    // This delegate enables asynchronous calls
	delegate void SetIndexCallback(string text);
     
       	private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
	    if (this.tabControl1.InvokeRequired)
		{	
	        	SetIndexCallback d = new SetIndexCallback(SetText);
			this.Invoke(d, new object[] { text });
		}
		else
		{
			tabControl1.SelectedIndex = int(text);
		}
	}
