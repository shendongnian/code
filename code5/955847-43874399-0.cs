    using (var connection = FACTORY.CreateConnection())
    {
        var channel = connection.CreateModel();
        channel.ExchangeDeclare(QUEUE_NAME, ExchangeType.Fanout, true);
        channel.QueueDeclare(QUEUE_NAME, true, false, false, null);
        channel.QueueBind(QUEUE_NAME, QUEUE_NAME, String.Empty, new Dictionary<string, object>());
         channel.BasicAcks += (sender, eventArgs) =>
                    {
                        //implement ack handle
                    };
        channel.ConfirmSelect();
    
        for (var i = 1; i <= numberOfMessages; i++)
        {
            var messageProperties = channel.CreateBasicProperties();
            messageProperties.SetPersistent(true);
            
            var message = String.Format("{0}\thello world", i);
            var payload = Encoding.Unicode.GetBytes(message);
            Console.WriteLine("Sending message: " + message);
            channel.BasicPublish(QUEUE_NAME, QUEUE_NAME, messageProperties, payload);
            channel.WaitForConfirmsOrDie();
        }
    }
