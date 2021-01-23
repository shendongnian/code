    public interface IConsume<T> where T : MessageBase
    {
        int RetryAllotment { get; }
        void Consume(T message);
    }
    public class ExampleConsumer : IConsume<ExampleMessage>
    {
        public int RetryAllotment { get { return 3; } }
        public void Consume(ExampleMessage message){...}
    }
