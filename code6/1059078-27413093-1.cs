    private void AcceptXPSData(object client)
    {
        string tempFilePath = fileShare + "XPStemp_" + instanceName + ".oxps";
        using (TcpClient tcpClient = (TcpClient)client)
        using (NetworkStream clientStream = tcpClient.GetStream())
        using (FileStream fs = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
        {
            byte[] message = new byte[65536];
            int bytesRead;
            while ((bytesRead = clientStream.Read(message, 0, message.Length)) > 0)
            {
                fs.Write(message, 0, bytesRead);
                // Add logging or whatever here
            }
        }
        // processXPS();
    }
