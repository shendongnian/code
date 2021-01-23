        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        int BytesReceivedCount = sp.BytesToRead;
        
        if(InvokeRequired)
        {
            Invoke((Action)(() =>
            {
                progressBar1.Value += BytesReceivedCount;
            }));
        }
        else
            progressBar1.Value += BytesReceivedCount;
    }
