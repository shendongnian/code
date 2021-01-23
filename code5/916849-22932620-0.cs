     using (var channel = myConnection.CreateModel())
                    {
                        channel.QueueDeclare("hello", false, false, false, null);
        
                        var consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume("", true, consumer);
     
