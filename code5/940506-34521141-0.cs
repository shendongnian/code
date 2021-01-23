    // the delegate now takes a string argument, holding the received data
    public delegate void UpdateText(string text);
    // checks for the correct EventType and calls updateText 
    // after all available data is read
    private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            if (e.EventType == SerialData.Chars)
            {
                // read all data and then handle
                updateTextBox(port.ReadExisting());
            }
            else
            {
                port.Close();
            }
        }
        catch
        {
            port.Close();
        }     
    }
    
    // called twice, once from the background thread
    // and by BeginInvoke
    public void updateTextBox(string text)
    {
        // do we need to be switch to the UI thread?
        if (tWGT.InvokeRequired)
        {
            // yes, so setup the delegate and pass on the parameter
            // notice how BeginInvoke will call this same method again
            tWGT.BeginInvoke(new UpdateText(updateTextBox), text);
        }
        else
        {
            // show the received data
            tWGT.AppendText(text);
            tWGT.ScrollToCaret();
        } 
    }
    
    // nicely close
    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        // if omitted you'll run into problems if this forms gets reopened
        if (port.IsOpen) port.Close();
        port.Dispose();
    }
