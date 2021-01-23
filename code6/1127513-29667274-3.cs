    public void NotifyAll()
    {
        foreach (IEventCaller caller in Singleton.Instance.EventCallers)
            caller.Hello();
    }
