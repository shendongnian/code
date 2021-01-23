    var factory = new ConnectionFactory { HostName = "localhost" };
    using (var connection = factory.CreateConnection())
    {
        using (var channel = connection.CreateModel())
        {
            var queueDeclareResponse = channel.QueueDeclare(Constants.QueueName, false, false, false, null);
            var consumer = new QueueingBasicConsumer(channel);
            channel.BasicConsume(Constants.QueueName, true, consumer);
            Console.WriteLine(" [*] Processing existing messages.");
            for (int i = 0; i < queueDeclareResponse.MessageCount; i++)
            {
                var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            }
            Console.WriteLine("Finished processing {0} messages.", queueDeclareResponse.MessageCount);
            Console.ReadLine();
        }
    }
