        List<IMockEvent> events = new List<IMockEvent>();
        public IMockEvent<K> GetMockEvent<T, K>()
        {
            return events.First(t => t is T) as IMockEvent<K>;
        }
        public void Add(IMockEvent evt)
        {
            events.Add(new MockStatusUpdate());
        }
