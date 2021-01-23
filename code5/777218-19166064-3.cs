    using (MyService client = new MyService())
    {
        client.credHeader = new Creds();
        client.credHeader.Username = "username";
        client.credHeader.Password = "pwd";
        rResponse = client.MyProxyMethodHere();
    }
