    var factory = new ConnectionFactory();
    using (var connection = factory.CreateConnection())
			{
				using (var channel = connection.CreateModel())
				{
					channel.QueueDeclare(queue: "HelloNewWorld",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
								 
								 string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "",
                                 routingKey: "HelloNewWorld",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] Sent {0}", message);
				}
			
			}
    //default localhost for rabbitmq
    http://localhost:15672/queues
