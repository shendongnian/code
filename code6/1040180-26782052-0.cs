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
                using (ThreadLock.Lock(_lock))
                {
                    _splashText = value;
                    OnPropertyChanged();
                    return;
                }
            }
            _dispatcher.Invoke(() =>
            {
                using (ThreadLock.Lock(_lock))
                {
                    _splashText = value;
                    OnPropertyChanged();
                }
            });
        }
    }
