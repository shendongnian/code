    public void StartMyAwesomeAsyncPostRequest(Func<string> callback)
    {
        TheActualAsyncPostRequest(callback);
    }
    public void TheActualAsyncPostRequest(Func<string> callback)
    {
        string result = callback();
    }
