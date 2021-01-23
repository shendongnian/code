    private void comPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        string inData = comPort1.ReadLine();
        this.Invoke(new EventHandler(processData));
    }
    
    private void processData(object sender, EventArgs e)
    {
        msgBoxLog.AppendText(inData);
    }
