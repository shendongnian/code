    public class SecondViewModel : Screen, IHandle<FooEvent>
        {
    
        private readonly IEventAggregator events;
    
        [ImportingConstructor]
        public SecondViewModel(IEventAggregator events)
        {
            DisplayName = "Second screen";
            this.events = events;
            events.Subscribe(this);
        }
    
        public bool Bar{get;set;}
    
        public void Handle(FooEvent message)
        {
            Bar = message.Foo;
        }
    }
