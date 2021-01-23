    private void checkPortDataTimer_Tick(object sender, EventArgs e)
    {
        //You may want to check available bytes instead of this.
        string recievedData = comPort.ReadExisting();
        if (!string.IsNullOrEmpty(recievedData))
            someTextBox.Text += recievedData;
    }
