    public void StartMyAwesomeAsyncPostRequest(Action<string> callback)
    {
        TheActualAsyncPostRequest(callback);
    }
    public void TheActualAsyncPostRequest(Action<string> callback)
    {
        callback("Foo");
    }
