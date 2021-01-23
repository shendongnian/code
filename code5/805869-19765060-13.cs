    public class MainWindowViewModel : NotificationObject
    {
        public MainWindowViewModel()
        {
            AltPressedCommand = new DelegateCommand(() => IsAltPressed = true);
            AltUnpressedCommand = new DelegateCommand(() => IsAltPressed = false);
        }
        public DelegateCommand AltPressedCommand { get; set; }
        public DelegateCommand AltUnpressedCommand { get; set; }
        private bool _IsAltPressed;
        public bool IsAltPressed
        {
            get { return _IsAltPressed; }
            set
            {
                if (value != _IsAltPressed)
                {
                    _IsAltPressed = value;
                    RaisePropertyChanged("IsAltPressed");
                }
            }
        }
    }
