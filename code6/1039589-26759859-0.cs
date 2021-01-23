    public class Producer
    {
        private BlockingCollection<Data> _pipe;
        public void Start()
        {
            while(!done)
            {
                var value = ProduceValue();
                _pipe.Add(value);
            }
            // Signal the consumer that we're finished
            _pipe.CompleteAdding();
        }
    }
