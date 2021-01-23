    ChannelFactory<IService> client = new ChannelFactory<IService>(binding, address);
    client.Credentials.UserName.UserName ="xxx";
    client.Credentials.UserName.Password ="pwd";
    var proxy = client.CreateChannel();
    ServiceResponse response=client.GetData();
