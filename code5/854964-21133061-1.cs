    public class FirstViewModel : Screen
    {
        private readonly IEventAggregator _events;
        [ImportingConstructor]
        public FirstViewModel(IEventAggregator events)
        {
           DisplayName = "First screen";
           _events = events;
        }
       public void PublishFooEvent()
       {
           _events.Publish(new FooEvent(true));
       }
