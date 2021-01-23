    [Event(1, Message = "New Message: {0}", Version = 1)]
    public void Starting(string name)
    {
        WriteEvent(1, name);
    }
