    if (sckCommunication.Connected)
    {
        sckCommunication.Disconnect(true);
    }
`
`
    if (!sckCommunication.Connected)
    {
        btnConnect.Enabled = true;
        btnDisconnect.Enabled = false;
    }
