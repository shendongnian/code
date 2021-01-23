    public static void PublishMessageToFanout()
    {
    	var factory = new ConnectionFactory { HostName = "localhost" };
    
    	using (var connection = factory.CreateConnection())
    	using (var channel = connection.CreateModel())
    	{
    		channel.ExchangeDeclare("messages", "fanout");
    
    		var message = new Message { Text = "This is a message to send" };
    
    		var json = JsonConvert.SerializeObject(message);
    		var body = Encoding.UTF8.GetBytes(json);
    
    		channel.BasicPublish("messages", string.Empty, null, body);
    	}
    }
