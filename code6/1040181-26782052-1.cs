    public string SplashText
    {
        get
        {
            using (ThreadLock.Lock(_lock))
            {
                return _splashText;
            }
        }
        set
        {
            if (_dispatcher.CheckAccess())
            {
                _splashText = value;
                OnPropertyChanged();
                return;
            }
            _dispatcher.Invoke(() =>
            {
                _splashText = value;
                OnPropertyChanged();
            });
        }
    }
