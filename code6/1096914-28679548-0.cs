    public async Task<string> TestTaskCompletionSource(CoreDispatcher dispatcher)
    {
        TaskCompletionSource<bool> completionSource = new TaskCompletionSource<bool>();
        await dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
        {
            try
            {
                Debug.WriteLine("Before delay");
                await Task.Delay(100);
                Debug.WriteLine("After delay and before exception");
                throw new Exception("Test");
    #pragma warning disable 162
                completionSource.SetResult(true);
    #pragma warning restore 162
            }
            catch (Exception e)
            {
                completionSource.SetException(e);
            }
        });
        await completionSource.Task;
    
        return "Test";
    }
