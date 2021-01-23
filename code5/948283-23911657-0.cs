    public void Pollback()
    {
       Timer poller = new Timer(5000);
       poller.Elapsed = OnTimedEvent;
       poller.Enabled = true;
    }
    private void OnTimedEvent(Object source, ElapsedEventArgs e){
       GsmPhone_MessageReceived(source, e);
       secondMethod(source, e);
    }
