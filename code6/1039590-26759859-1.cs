    public class Consumer
    {
        private BlockingCollection<Data> _pipe;
        public void Start()
        {
            foreach(var value in _pipe.GetConsumingEnumerable())
            {
                // GetConsumingEnumerable will block until a value arrives and 
                // will exit when producer calls CompleteAdding()
                Process(value);
            }
        }
    }
