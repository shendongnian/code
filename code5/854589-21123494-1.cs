    public void Delete(string id)
    {
        ManualResetEvent waitHandle = new ManualResetEvent(false);
        _handlerToServerObj.OnDelete += () => waitHandle.Set();
        _handlerToServerObj.Delete(id);
        waitHandle.WaitOne();
    }
