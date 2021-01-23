    public class Module1
    {
        private IEventAggregator _eventAggregator;
        public Module1(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        public DoSomeWork()
        {
            // Busy the UI by publishing the above event
            _eventAggregator.GetEvent<BusyUserInterfaceEvent>().Publish(true);
        }
        public FinishDoingSomeWork() 
        {
            // Unbusy the UI by publishing the above event with 'false'
            _eventAggregator.GetEvent<BusyUserInterfaceEvent>().Publish(false);
        }
    }
