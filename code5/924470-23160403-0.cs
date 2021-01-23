    class ViewModel1 : PropertyChangedBase
    {
        private IEventAggregator _Event;
        public ViewModel1(IEventAggregator events)
        {
            _Event = events;
            _Events.Publish(new TestEvent(5));
        }
    }
    
    class ViewModel2 : PropertyChangedBase, IHandle<TestEvent>
    {
        private IEventAggregator _Events;
        public ViewModel2(IEventAggregator events)
        {
            _Events = events;
            _Events.Subscribe(this);
        }
    
        public void Handle(TestEvent message)
        {
            // do something with the incoming message
        }
    }
    
    class TestEvent
    {
        public int foo { get; set; }
        public TestEvent(int someint)
        {
            foo = someint;
        }
    }
