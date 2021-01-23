    public class Job: PropertyChangedBase
    {
        public string Name { get; set; }
        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                _isRunning = value;
                OnPropertyChanged("IsRunning");
            }
        }
        public Command CancelCommand { get; set; }
        public Job()
        {
            CancelCommand = new Command(() => IsRunning = !IsRunning);
        }
    }
