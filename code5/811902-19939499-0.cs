    IConnectionFactory factory = new ConnectionFactory(new Uri("tcp://localhost:61616?wireformat.version=2"));
    using (IConnection connection = factory.CreateConnection())
    {
        connectio.ClientId = "MyClientId";
        connection.Start();
        ISession session = connection.CreateSession();
        ActiveMQTopic topic = new ActiveMQTopic("MARKETADAPTERS.ORDERBOOKSNAPSHOT");
        consumer = session.CreateDurableConsumer(topic,"OBSnap",null, false);
    }
