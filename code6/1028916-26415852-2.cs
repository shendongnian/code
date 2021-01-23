    bus.Subscribe<string>("", HandleClusterNodes);
    
    private static void HandleClusterNodes(string obj)
    {
        var myMessage = (MessageB)JsonConvert.DeserializeObject<MessageB>(obj);
        Console.WriteLine(myMessage.Text);
    }
