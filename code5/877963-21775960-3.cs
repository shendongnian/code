    if (value)
    {
        var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(2000) };
        timer.Tick += delegate
        {
            timer.Stop();
            _isProgressBarLoading = true;
            NotifyOfPropertyChange(() => IsProgressBarLoading);
        };
        timer.Start();
    }
    else
    {
        _isProgressBarLoading = false;
        NotifyOfPropertyChange(() => IsProgressBarLoading);
    }
                
