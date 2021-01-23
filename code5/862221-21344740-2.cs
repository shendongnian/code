    proximityDevice = Windows.Networking.Proximity.ProximityDevice.GetDefault();
    proximityDevice.SubscribeForMessage("Windows.Tietgen", new MessageReceivedHandler((proxDevice, message) =>
    {
        Debug.WriteLine(message.DataAsString);
    }));
