    private void btnConnect_Click(object sender, EventArgs e)
    {
        AsynchronousClient client = new AsynchronousClient();
        client.Port = Int32.Parse(tbPort.Text);
        client.IpAddress = tbAddress.Text;
        
        //then connect to the remote device and send data
        //client.Connect();
        //client.Send(data);  
     }
