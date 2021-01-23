    public void DoSomething(string input, Action<int> callback)
    {
        // Do something with input
        int result = ...;
        callback(result);
    }
