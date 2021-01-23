    private void sendButton_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.Enabled = false;
        string host = addressTextBox.Text;
        pingDetailsTextBox.Text = String.Empty;
        PingReply pngReply = null;
        if (!String.IsNullOrEmpty(host))
        {            
            for (int i=0; i < 3; i++)
            {
                pingDetailsTextBox.Text +=
                    "Pinging " + host + " . . .\r\n";
                IPStatus ipStatus = CheckConn(host, ref pngReply);
                string strStatus = GetStatusString(ipStatus);
                if (pngReply.Status == IPStatus.Success)
                {
                    pingDetailsTextBox.Text +=
                        "  " + pngReply.Address.ToString() + " " +
                        pngReply.RoundtripTime.ToString(
                        NumberFormatInfo.CurrentInfo) + "ms" + "\r\n";
                }
                else
                {
                    pingDetailsTextBox.Text +=
                        "  " + strStatus + "\r\n";
                }
            }
        }
        else
            MessageBox.Show("No host to ping.");
        btn.Enabled = true;
    }
