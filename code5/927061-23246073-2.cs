    public void SetValue(int n)
    {
        if (value != n) // check if the value actually changed
        {
            value = n;
            OnNumChanged(); // call the event "in a save way", see below
        }
    }
    protected virtual void OnNumChanged()
    {
        if (ChangeNum != null) // check if someone is listening - PROBLEM: see below
            ChangeNum(); // trigger the event and call all event handlers registered
    }
