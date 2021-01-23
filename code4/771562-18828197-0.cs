    private void getDetails(out IPAddress ipAddress, out int port)
    {
        try
        {
            ipAddress = IPAddress.Parse(textboxIp.Text);
            port = int.Parse(textboxPort.Text);
        }
        catch (Exception ex)
        {
            ipAddress = null;
            port = -1;
            MessageBox.Show(ex.Message);
        }
    }
