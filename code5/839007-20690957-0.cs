    private void Receive(string receivedFileName, int fileSize)
    {
        activity.AppendText("File downloading to " + fileDir + " destination");
        using (FileStream stream = new FileStream(fileDir + "//" + fileName, FileMode.Create, FileAccess.Write)
        {
            byte[] buffer = new byte[1024];
            int totalBytesReceived = 0;
            while (totalBytesReceived < fileSize)
            {
                int bytesReceived = tempSocket.Receive(buffer);
                if (bytesReceived > 0)
                {
                    stream.Write(buffer, 0, bytesReceived);
                    totalBytesReceived += bytesReceived;
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
        }
        activity.AppendText("File downloaded..."); // Updates activity log(text box.)
    }
