    ChannelFactory<LoginReference.MyService> myChannelFactory = new ChannelFactory<LoginReference.MyService>("MyService");
    // Create a channel.
    LoginReference.MyService wcfClient1 = myChannelFactory.CreateChannel();
    string s = wcfClient1.getVersionString();
    Console.WriteLine(s);
    ((IClientChannel)wcfClient1).Close();
