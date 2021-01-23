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
       myTimer.Change(Timeout.Infinite, Timeout.Infinite);
       Deployment.Current.Dispatcher.BeginInvoke(() =>
       {
           _isProgressBarLoading = true;
            NotifyOfPropertyChange(() => IsProgressBarLoading);
        });
    }
