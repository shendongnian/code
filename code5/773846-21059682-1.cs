    using (TcpClient client = new TcpClient())
    {
        client.Connect("pop3.live.com", 995);
        while(variableThatRepresentsRunning)
        {
            // talk to POP server
        }
    }
