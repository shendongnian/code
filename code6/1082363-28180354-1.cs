    public async Task WaitIfPausedAsync(PauseToken pauseToken, CancellationToken cancellationToken, IProgressBar progressBar)
    {
        for (int i = 0; i < 3600; i++)
        {
            ThrowExceptionIfCancelled(cancellationToken, progressBar);
            if (pauseToken.IsPaused)
            {
                await Task.Delay(1000)
            }
            else
            {
                break;
            }
        }
    }
