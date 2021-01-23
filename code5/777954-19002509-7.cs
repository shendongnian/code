    public void ReceiveData()
        {
            new Thread(() =>
            {
                while (true)
                {
                    byte[] ReceivedBytes = new byte[1024];
                    int ReceivedBytesLength = Client.Receive(ReceivedBytes, 0, ReceivedBytes.Length, SocketFlags.None);
                    string ReceivedMessage = Encoding.Default.GetString(ReceivedBytes, 0, ReceivedBytesLength);
                    textBox1.Text += " Received Message From Server Is : " + ReceivedMessage + Environment.NewLine;
                }
            }).Start();
        }
