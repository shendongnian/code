    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        _eventAggregator.GetEvent<ApplicationClosingEvent>().Publish(e);
    
        base.OnClosing(e);
    }
