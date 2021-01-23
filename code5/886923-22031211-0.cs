    void DoWork()
    {
        foreach(var message in collection.GetConsumingEnumerable())
        {
            SendMessage();
        }
    }
