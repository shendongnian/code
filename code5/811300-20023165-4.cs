    private void myForm_OnConnectEvent(object sender, EventArgs e) 
    {
        writeLog("Connected");
    }
    private void writeLog(string logMessage) 
    {
        if(logTextBox.InvokeRequired)
        {
            logTextBox.BeginInvoke(new Action<string>(writeLog), logMessage);
            return;
        }
        var logLine = String.Format("{0:g}: {1}{2}", DateTime.Now, logMessage, Enviorment.NewLine);
        logTextBox.AppendText(logLine);
    }
