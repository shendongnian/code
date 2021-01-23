    HandlerRegistry.Register<Message1, Message1Handler>();
    HandlerRegistry.Register<Message2, Message2Handler>();
    var messages = new List<MessageBase>()
        {
            new Message1(),
            new Message2()
        };
    foreach (var message in messages)
    {
        var handler = HandlerRegistry.Resolve(message);
        handler.Execute(message);               
    }
