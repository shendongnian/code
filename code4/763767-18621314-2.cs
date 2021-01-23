    private string SendFile(string tosend, string tosendname)
    {
        ipadd = IPAddress.Parse(textBox2.Text);
        ep = new IPEndPoint(ipadd, 6112);
        Sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        Sender.Connect(ep);
        byte[] filetosend = System.IO.File.ReadAllBytes(tosend);
        byte[] filesizeBytes = BitConverter.GetBytes(filetosend.Length);
        Sender.Send(filesizeBytes); // sends the length as an integer
        // note: You could use Socket.Send(filetosend) here.
        // but I'll show an example of sending in chunks.
        int totalBytesSent = 0;
        while (totalBytesSent < filetosend.Length)
        {
            int bytesLeft = filetosend.Length - totalBytesSent;
            int bytesToSend = Math.Min(bytesLeft, 7000);
            Sender.Send(filetosend, totalBytesSent, bytesToSend);
            richTextBox1.Invoke((MethodInvoker)delegate 
                { richTextBox1.Append(totalBytesSent + " bytes sent\n"); });
            totalBytesSent += bytesToSend;
        }
        richTextBox1.Invoke((MethodInvoker)delegate { richTextBox1.AppendText("Done"); });
        return "";
    }
