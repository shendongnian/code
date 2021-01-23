    public event Action BeforeDispose;
    public event Action AfterDispose;
    
    public virtual void Close ()
    {    
        if (BeforeDispose != null) BeforeDispose.Invoke();
        Dispose();
        if (AfterDispose != null) AfterDispose.Invoke();
        RaiseClosed();
    }
