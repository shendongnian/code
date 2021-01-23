    public class MainWindowViewModel : NotificationObject
    {
        private bool _isChecked;
        private bool _isEnabled;
        public MainWindowViewModel()
        {
            ToggleCommand = new DelegateCommand(() =>
                {
                    IsChecked = !IsChecked;
                    IsEnabled = !IsEnabled;
                });
        }
        public DelegateCommand ToggleCommand { get; set; }
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                RaisePropertyChanged(() => IsChecked);
            }
        }
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                RaisePropertyChanged(() => IsEnabled);
            }
        }
    }
