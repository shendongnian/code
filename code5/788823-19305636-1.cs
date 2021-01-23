    if (token!=null)
    {
       socket.SetRequestHeader("Token", token);
       socket.SetRequestHeader("Lang", lang);
       socket.SetRequestHeader("idInstallation", idInstalation);
    }
    Task t = Task.Factory.StartNew(()=>{socket.ConnectAsync(server);});
    Task.WaitAll(t);
    System.Diagnostics.Debug.WriteLine("Connected");
    connected = true;
    writer = new DataWriter(socket.OutputStream);
    messageNumber = 1;
