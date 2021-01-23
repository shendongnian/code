    private void Receive(string receivedFileName)
    {
        byte[] buffer = new byte[1024];
        // receive file size
        if (tempSocket.Receive(buffer, sizeof(ulong), SocketFlags.None) != sizeof(ulong))
        {
            // failed to receive the size
            return;
        }
        ulong fileSize = BitConverter.ToUInt64(buffer, 0);
        // receive file data
        activity.AppendText("File downloading to " + fileDir + " destination");
        using (FileStream stream = new FileStream(fileDir + "//" + fileName, FileMode.Create, FileAccess.Write)
        {
            ulong totalBytesReceived = 0;
            while (totalBytesReceived < fileSize)
            {
                int bytesReceived = tempSocket.Receive(buffer);
                if (bytesReceived > 0)
                {
                    stream.Write(buffer, 0, bytesReceived);
                    totalBytesReceived += (ulong)bytesReceived;
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
        }
        activity.AppendText("File downloaded..."); // Updates activity log(text box.)
    }
