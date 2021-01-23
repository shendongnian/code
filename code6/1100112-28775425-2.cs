    Semaphore _frameIsProcessing = new Semaphore(5, 5); //Allows for up to 5 frames to be requested at once before it starts blocking requests.
    private void ShowFrames()
    {
        while (run)
        {
            _fetchFrame.WaitOne();
            _previousFrameCancellationToken.Cancel();
            _previousFrameCancellationToken = new CancellationTokenSource();
            _frameIsProcessing.WaitOne();
            Cache.Default.GetAsync(CurrentFrameTime).ContinueWith((task) =>
            {
                _frameIsProcessing.Release();
                if(_previousFrameCancellationToken.IsCancellationRequested)
                    return;
                var frameTime = task.Result.Time;
                var frameImage = task.Result.Image;
                Dispatcher.BeginInvoke(new Action(() => ShowFrame(frameTime, frameImage)));
            });
        }
    }
