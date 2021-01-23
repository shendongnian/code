    private async void StartReceiving()
    {
        Receiver.Bind(new IPEndPoint(IPAddress.Parse("0"), 6112));
        Receiver.Listen(1000);
        string filename = "Downloadedfile";
        bool cont = false;
        while (true)
        {
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            Client = Receiver.Accept();
            // read the length
            byte[] filesizeBytes = new byte[4];
            int totalBytesReceived = 0;
            while (totalBytesReceived < 4)
            {
                int bytesRead = Client.Receive(
                    filesizeBytes, totalBytesReceived, 4-totalBytesReceived);
                totalBytesReceived += bytesRead;
            }
            int filesize = BitConverter.ToInt32(filesizeBytes);
            richTextBox1.Invoke((MethodInvoker)delegate 
                { richTextBox1.AppendText(filesize.ToString() + "\n"); });
            // now read the file
            using (FileStream writer = File.Create("DownloadedFile.jpg"))
            {
                byte[] readBuffer = new byte[7000];
                totalBytesReceived = 0;
                while (totalBytesReceived < filesize)
                {
                    int bytesToRead = Math.Min(7000, filesize - totalBytesReceived);
                    int bytesRead = Client.Receive(readBuffer, 0, bytesToRead);
                    totalBytesRead += bytesRead;
                    writer.Write(readBuffer, 0, bytesRead);
                    richTextBox1.Invoke((MethodInvoker)delegate 
                        { richTextBox1.AppendText("Read " + bytesRead.ToString() + "bytes\n"); });
                }
                richTextBox1.Invoke((MethodInvoker)delegate 
                    { richTextBox1.AppendText("Done. " + totalBytesRead.ToString() + " bytes\n"); });
            }
       }
