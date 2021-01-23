    public async Task Login(String UserName, Action<bool> callback)
    {
        // The delegate passed to `Task.Run` is executed on a ThreadPool thread.
        bool LoginResult = await Task.Run(() => _proxy.Login(UserName));
        // OR
        // await _proxy.LoginAsync(UserName);
        // if you have an async WCF contract.
        // The callback is executed on the thread which called Login.
        callback(LoginResult);
    }
