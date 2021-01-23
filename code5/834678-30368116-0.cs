    private void ConsumeMessages(string queueName)
    {
    	using (IConnection conn = factory.CreateConnection())
    	{
    		using (IModel channel = conn.CreateModel())
    		{
    			var consumer = new QueueingBasicConsumer(channel);
    			channel.BasicConsume(queueName, false, consumer);
    			Trace.WriteLine(string.Format("Waiting for messages from: {0}", queueName));
    			
    			while (true)
    			{
    				BasicDeliverEventArgs ea = null;
    				try
    				{
    					ea = consumer.Queue.Dequeue();
    				}
    				catch (EndOfStreamException endOfStreamException)
    				{
    					Trace.WriteLine(endOfStreamException);
    					// If you want to end listening end of queue call break;
    					break;    
    				}
    				if (ea == null) break;
    				var body = ea.Body;
    				// Consume message how you want
    				Thread.Sleep(300);
    				channel.BasicAck(ea.DeliveryTag, false);
    			}
    		}
    	}
    }
