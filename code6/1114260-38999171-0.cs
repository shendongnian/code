    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (ch, ea) =>
                    {
                        var body = ea.Body;
                        // ... process the message
                        ch.BasicAck(ea.DeliveryTag, false);
                    };  
    String consumerTag = channel.BasicConsume(queueName, false, consumer);
