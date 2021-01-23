    public bool ProcessData(Action<string> callback)
    {
        if (callback != null)
        {
            callback("doing this");
        }
    }
