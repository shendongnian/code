    SubscribeToMessages("sms-messages", (s) => Console.WriteLine("SMS Message: {0}", s));
    SubscribeToMessages("email-messages", (s) => Console.WriteLine("Email Message: {0}", s));
    public static void SubscribeToMessages(string queueName, Action<string> messageAction)
    {
    	var factory = new ConnectionFactory() { HostName = "localhost" };
    	
    	using (var connection = factory.CreateConnection())
    	using (var channel = connection.CreateModel())
    	{
    		channel.ExchangeDeclare("messages", "fanout");
    		channel.QueueDeclare(queueName, true, false, false, null);
    		channel.QueueBind(queueName, "messages", string.Empty);
    
    		var consumer = new QueueingBasicConsumer(channel);
    
    		channel.BasicConsume(queueName, true, consumer);
    
    		while (true)
    		{
    			var ea = consumer.Queue.Dequeue();
    
    			var body = ea.Body;
    			var message = Encoding.UTF8.GetString(body);
    			messageAction(message);
    		}
    	}
    }
