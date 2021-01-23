    string connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
    						   
    MessagingFactory factory = MessagingFactory.CreateFromConnectionString(connectionString);
    MessageSender testQueue = factory.CreateMessageSender("TestTopic");
    
    BrokeredMessage message = new BrokeredMessage("Test message ");
    testQueue.Send(message);
