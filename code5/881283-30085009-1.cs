    private async void DoWork()
    {
        // WORK STUFF
        {
            workerCancel.Token.ThrowIfCancellationRequested();
        }
    }
