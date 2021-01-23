    public async Task Login(string userName, Action<bool> callback)
    {
        // The delegate passed to `Task.Run` is executed on a ThreadPool thread.
        bool loginResult = await Task.Run(() => _proxy.Login(userName));
        // OR
        // await _proxy.LoginAsync(UserName);
        // if you have an async WCF contract.
        // The callback is executed on the thread which called Login.
        callback(loginResult);
    }
