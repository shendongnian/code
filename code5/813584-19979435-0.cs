    private async void ScreenShotTask()
    {
        try
        {
            while (true)
            {
                _cancelToken.ThrowIfCancellationRequested();
                screenShotFunction();
                await Task.Delay(new TimeSpan(0, 0, 10, 0), _cancelToken);
            }
        }
        catch (TaskCanceledException)
        {
            // what should happen when the task is canceled
        }
    }
