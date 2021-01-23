    public async void Recur(Action action, TimeSpan time, CancellationToken token)
    {
        while(!token.IsCancellationRequested)
        {
            action();
            try
            {
                await Task.Delay(time, token);
            }
            catch(TaskCancelledException)
            {
                break;
            }
        }
    }
