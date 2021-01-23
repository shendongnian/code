    private void Arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
            if(richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(
                   (Action)delegate 
                   { 
                     richTextBox1.AppendText(Arduino.ReadExisting()); 
                   }
                );
            }
    }
