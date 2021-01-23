    class TimerModel : INotifyPropertyChanged
    {
        private TimeSpan _timeLeft;
        private readonly ICommand _startCommand;
        public TimeSpan TimeLeft
        {
            get { return _timeLeft; }
            set
            {
                if (value != _timeLeft)
                {
                    _timeLeft = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand Start { get { return _startCommand; } }
        public TimerModel()
        {
            _startCommand = new StartCommand(this);
        }
        private class StartCommand : ICommand
        {
            private bool _running;
            private readonly TimerModel _timerModel;
            public bool CanExecute(object parameter)
            {
                return !_running;
            }
            public event EventHandler CanExecuteChanged;
            public StartCommand(TimerModel timerModel)
            {
                _timerModel = timerModel;
            }
            public void Execute(object parameter)
            {
                TimeSpan total = TimeSpan.FromSeconds(5);
                DispatcherTimer timer = new DispatcherTimer();
                Stopwatch sw = new Stopwatch();
                timer.Interval = TimeSpan.FromMilliseconds(100);
                timer.Tick += (sender, e) =>
                {
                    TimeSpan timeLeft = total - sw.Elapsed;
                    if (timeLeft <= TimeSpan.Zero)
                    {
                        timer.Stop();
                        timeLeft = TimeSpan.Zero;
                        _running = false;
                        OnCanExecuteChanged();
                    }
                    _timerModel.TimeLeft = timeLeft;
                };
                sw.Start();
                timer.Start();
                _running = true;
                OnCanExecuteChanged();
            }
            private void OnCanExecuteChanged()
            {
                EventHandler handler = CanExecuteChanged;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
