    ... 
    {    
        string objectName = "SomeObjectName";
        var dispatcherTimer = new DispatcherTimer();
    
        dispatcherTimer.Tick += (sender, e) => { myTick(sender, e, objectName); };
    }
    private void myTick(object sender, EventArgs e, string objectName)
    {
        [...]
    }
