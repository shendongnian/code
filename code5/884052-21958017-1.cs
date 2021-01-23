    internal class MassTransitConsumer<TMessage, TConsumer> : Consumes<TMessage>.Context
        where TMessage : MessageBase
        where TConsumer : IConsume<TMessage>
    {
        private readonly TConsumer _consumer;
    
        public MassTransitConsumer(TConsumer consumer)
        {
            _consumer = consumer;
        }
    
        public void Consume(IConsumeContext<TMessage> ctx)
        {
            try
            {
                _consumer.Consume(ctx.Message);
            }
            catch
            {
                if (ctx.RetryCount >= _consumer.RetryAllotment)
                    throw;
    
                ctx.RetryLater();
            }
        }
    }
