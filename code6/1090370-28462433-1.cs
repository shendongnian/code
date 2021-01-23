    //put in the Init method
    Signal.SignalRaised += OnGlobalHandling;
    
    public void OnGlobalHandling(object sender, SignalRaisedEventArgs e)
    {
        var signal = (Signal)sender;
        //send email
    }
