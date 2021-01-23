    public class MainVM : INotifyPropertyChanged
    {
        private bool _bSwitch;
        private readonly DispatcherTimer flashButtonChangeTimer = new DispatcherTimer();
    
        public bool IsRecycleOn
        {
            get { return _bSwitch; }
                
        }
    
        public bool IsCopyOn
        {
            get { return !_bSwitch; }
        }
    
        public MainVM()
        {
            flashButtonChangeTimer.Interval = TimeSpan.FromSeconds(2);
            flashButtonChangeTimer.Tick += (sender, args) =>
            {
                _bSwitch = ! _bSwitch;
                OnPropertyChanged("IsCopyOn");
                OnPropertyChanged("IsRecycleOn");
            };
            flashButtonChangeTimer.Start();
    
        }
    
        /// <summary>Event raised when a property changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;
    
        /// <summary>Raises the PropertyChanged event.</summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
    }
