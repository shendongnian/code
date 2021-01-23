    private void button1_Click(object sender, System.EventArgs e)
    {
        UdpClient udpClient = new UdpClient();
        udpClient.Connect(txtbHost.Text, 8080);
        Byte[] senddata = Encoding.ASCII.GetBytes("Hello World");
        udpClient.Send(senddata, senddata.Length);
    }
