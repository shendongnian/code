    public event EventHandler SomeEvent
    {
        add { mSomeEvent += value; }
        remove { mSomeEvent -= value; }
    }
    private void RaiseSomeEvent()
    {
        var handler = mSomeEvent;
        if( handler != null ) handler( this, EventArgs.Empty );
    }
    private EventHandler mSomeEvent;
