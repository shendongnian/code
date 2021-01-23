    public event EventHandler MyEvent;
    protected void OnMyEvent(EventArgs e)
    {
        EventHandler myEvent = MyEvent;
        Thread.MemoryBarrier();
        if (myEvent != null)
        {
            myEvent(this, e);
        }
    }
