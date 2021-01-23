    public class SubscriptionMetadata
    {
        public SubscriptionMetadata(Type consumer)
        {
            if(!typeof(IConsumer).IsAssignableFrom(consumer))
            {
                string message = string.Format(
                    "{0} does not implement {1}",
                    typeof(IConsumer).Name,
                    consumer.Name);
                throw new ArgumentOutOfRangeException("consumer", message);
            }
            this.ConsumerType = consumer;
        }
        public Type ConsumerType { get; private set; }
    }
