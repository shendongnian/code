    System.Threading.Timer myTimer = null;
    private bool _isProgressBarLoading = false;
    public bool IsProgressBarLoading
    {
        get { return _isProgressBarLoading; }
        set
        {
           if (_isProgressBarLoading != value)
           {
               if (value)
               {
                    if (myTimer == null)
                    {
                       myTimer = new System.Threading.Timer(Callback, null, 3000, Timeout.Infinite);
                    }
                    else myTimer.Change(3000, Timeout.Infinite);
                    // it should also work if you create new timer every time, but I think it's
                    // more suitable to use one
               }
               else
               {
                    _isProgressBarLoading = false;
                    NotifyOfPropertyChange(() => IsProgressBarLoading);
               }
           }
        }
    }
    private void Callback(object state)
    {
       Deployment.Current.Dispatcher.BeginInvoke(() =>
       {
           _isProgressBarLoading = true;
            NotifyOfPropertyChange(() => IsProgressBarLoading);
        });
    }
