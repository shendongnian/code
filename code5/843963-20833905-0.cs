    private int? _Woo;
    public int? Woo
    {
        get
        {
            if (!_Woo.HasValue)
            {
                var task = Task.Factory.StartNew<int>(model.GetWoo, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default());
                task.ContinueWith(a => { _Woo = a.Result; }, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.FromCurrentSynchronizationContext());
            }
            return _Woo;
        }
        set
        {
            _Woo = value;
            NotifyPropertyChange("Woo");
        }
    }
