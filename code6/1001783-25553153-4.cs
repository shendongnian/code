    public class SettingsViewModel: IHandle<TotalTimeChangedMessage>
    {
        private readonly IEventAggregator eventAggregator;
        public SettingsViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.Subscribe(this);
        }
        public void Handle(TotalTimeChangedMessage message)
        {
            // Use message.TotalTime as necessary
        }
    }
