    public void PublishTest()
    {
        var advancedBus = RabbitHutch.CreateBus("host=localhost;virtualHost=Test;username=guest;password=guest;").Advanced;
        var routingKey = "SimpleMessage";
        // declare some objects
        var queue = advancedBus.QueueDeclare("Q.TestQueue.SimpleMessage");
        var exchange = advancedBus.ExchangeDeclare("E.TestExchange.SimpleMessage", ExchangeType.Direct);
        var binding = advancedBus.Bind(exchange, queue, routingKey);
        var message = new SimpleMessage() {Test = "HELLO"};
        for (int i = 0; i < 100; i++)
        {
            advancedBus.Publish(exchange, routingKey, true, false, new Message<SimpleMessage>(message));
        }
        advancedBus.Dispose();
    }
