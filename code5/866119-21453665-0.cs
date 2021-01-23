    bool _continue = true;
    string message = string.Empty;
    string number = string.Empty;
    private void serialPort_DataNewReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        // stop listening (by ignoring call)
        if (!_continue)
            return;
        // proceed
        SerialPort sp = (SerialPort)sender;
        message = sp.ReadExisting();
        if (message.Contains("MESG"))
        {
            string[] strFirstStep = Regex.Split(message, "\r\nNMBR =");
            string[] strLastStep = Regex.Split(strFirstStep[1], "\r\n");
            number = strLastStep[0];
            _continue = false;
            // do a work if number is received
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }
