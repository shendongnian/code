    public class MainWindow
    {
        private IEventAggregator _eventAggregator;
        public MainWindow(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            // Subscribe to any messages of the defined type on the UI thread
            // The BusyUserInterface method will handle the event
            _eventAggregator.GetEvent<BusyUserInterfaceEvent>().Subscribe(BusyUserInterface, ThreadOption.UIThread);
        }
        public BusyUserInterface(bool busy)
        {
            // Toggle the UI - pseudocode here!
            TickerActive = busy;
        }
    }
