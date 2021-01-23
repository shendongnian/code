     class MyConsumer : DefaultBasicConsumer {
    
        public MyConsumer(IModel model):base(model)
        {
         
        }
        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body) {
          var message = Encoding.UTF8.GetString(body);
          Console.WriteLine(" [x] Received {0}", message);
        }
      }
      
      
      class Program
      {
        static void Main(string[] args)
        {
    
          var factory = new ConnectionFactory() { Uri = "amqp://aa:bbb@lemur.cloudamqp.com/xxx" };
          using (var connection = factory.CreateConnection())
          {
            using (var channel = connection.CreateModel())
            {
             channel.QueueDeclare("hello", false, false, false, null);
            var consumer = new MyConsumer(channel);
             String tag = channel.BasicConsume("hello", true, consumer);
            Console.WriteLine(" [*] Waiting for messages." +
                                   " any key to exit");
            Console.ReadLine();
            channel.BasicCancel(tag);
    
              
              /*while (true)
              {
               /////// DON'T USE THIS   
               var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
              }*/
            }
          }
    
    
        }
      } 
