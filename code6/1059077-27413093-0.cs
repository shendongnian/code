    private void AcceptXPSData(object client)
    {
        string tempFilePath = fileShare + "XPStemp_" + instanceName + ".oxps";
        using (TcpClient tcpClient = (TcpClient)client)
        using (NetworkStream clientStream = tcpClient.GetStream())
        using (FileStream fs = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
        {
            clientStream.CopyTo(fs);
        }
        // processXPS();
    }
