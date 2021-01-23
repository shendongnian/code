    async Task SendDataToUIAsync()
    {
        var tcs = new TaskCompletionSource<object>();
        _synchronizationContext.Post(a => 
        { 
            try
            {
                _callback(a);
                tcs.SetResult(Type.Missing);
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
        }, data);
        await tcs.Task;
    }
