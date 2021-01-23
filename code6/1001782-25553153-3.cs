    public class MainViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        public MainViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        public string TotalTime
        {
            set
            {
                this.totalTime = value;
                _eventAggregator.Publish(new TotalTimeChangedMessage(this.totalTime));
            }
        }
    }
