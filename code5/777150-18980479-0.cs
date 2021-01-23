    int  count = 0;
    private void btnStartClient_Click(object sender, EventArgs e)
    {
        try
        {
             richTextBox1.AppendText("Connected to server!" + "\n");
             m_connectedIpAddresses.Add(((IPEndPoint)sock.Client.LocalEndPoint).Address.ToString());
        }
        catch (Exception e1)
        {
                MessageBox.Show("Cannot connect to server");
        }
    }
    
    private void btnAnotherButton_Click(object sender, EventArgs e)
    {
        count = m_connectedIpAddresses.Count;
    }
