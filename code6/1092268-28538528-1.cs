    class SampleConsumer : DefaultBasicConsumer
        {
    
            public SampleConsumer(IModel channel) : base(channel)
            {
            }
    
            public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey,
                IBasicProperties properties, byte[] body)
            {
     .....
