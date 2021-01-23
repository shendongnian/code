    private void Read()
    {
        StreamReader r = new StreamReader(clientObject.GetStream());
        string str = r.ReadToEnd();
        if ((str == null) || (str == "")) { Disconnect(); }
        Client_dataReceived(str);
    }
