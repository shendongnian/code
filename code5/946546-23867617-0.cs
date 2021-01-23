    public async void Test() 
    {
        ServiceSoapClient GameClient = new ServiceSoapClient();
        GameClient.GetMasterExitCompleted += _clientGetMasterExitCompleted;
        await GameClient.GetMasterExitAsync(RoomID);
        Console.WriteLine(MasterExit);
    }
