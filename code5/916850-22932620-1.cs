     using (var channel = myConnection.CreateModel())
                    {
                     channel.QueueDeclare("hello", false, false, false, null);
                       string message = "Hello World!";
                       var body = Encoding.UTF8.GetBytes(message);
        
                        channel.BasicPublish("", "", null, body);
                        Console.WriteLine(" [x] Sent {0}", message);
                    }
   
