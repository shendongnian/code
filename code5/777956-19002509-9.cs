    public void ReceiveData()
        {
            new Thread(() =>
            {
                while (true)
                {
                    var Client = Soc.Accept();
                    ClientList.Add(Client);
                    label3.Text = ClientList.Count.ToString() + "/" + MaxClients;
                    textBox2.Text += " Client Located At Ip : " + Client.RemoteEndPoint.ToString().Split(':')[0].ToString() + " Is Now Connected To Server " + Environment.NewLine;
                    new Thread(() =>
                    {
                        while (true)
                        {
                            byte[] ReceivedBytes = new byte[1024];
                            int ReceivedDataLength = Client.Receive(ReceivedBytes, 0, ReceivedBytes.Length, SocketFlags.None);
                            string MessageFromClient = Encoding.Default.GetString(ReceivedBytes, 0, ReceivedDataLength);
                            textBox2.Text += " Message Sent to Server : " + MessageFromClient + Environment.NewLine;
                        }
                    }).Start();
                }
            }).Start();
        }
