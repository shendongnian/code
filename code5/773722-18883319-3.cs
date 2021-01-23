    public void StartMyAwesomeAsyncPostRequest(Action callback)
    {
        TheActualAsyncPostRequest(callback);
    }
    
    public void TheActualAsyncPostRequest(Action callback)
    {
        callback();
    }
