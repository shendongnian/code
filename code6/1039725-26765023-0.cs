    public void Calling()
    {
        Func<string, string> handler = Message;
        if (handler != null)
        {
            handler("Hello world!");
        }
    }
