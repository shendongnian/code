    try
    {
        udpClient.Send(sendBytes, sendBytes.Length);
    }
    catch (Exception exc)
    {
        // handle the error
    }
