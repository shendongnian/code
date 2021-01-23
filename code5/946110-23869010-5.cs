    public class ProducerConsumerHub<T>
    {
        TaskCompletionSource<Empty> _consumer = new TaskCompletionSource<Empty>();
        TaskCompletionSource<T> _producer = new TaskCompletionSource<T>();
        // TODO: make thread-safe
        public async Task ProduceAsync(T data)
        {
            _producer.SetResult(data);
            await _consumer.Task;
            _consumer = new TaskCompletionSource<Empty>();
        }
        public async Task<T> ConsumeAsync()
        {
            var data = await _producer.Task;
            _producer = new TaskCompletionSource<T>();
            _consumer.SetResult(Empty.Value);
            return data;
        }
        struct Empty { public static readonly Empty Value = default(Empty); }
    }
