    /// <exception cref="TaskCanceledException" />
    internal async Task WaitForFileToFinishChangingContentAsync(string filePath, int pollingIntervalMs, CancellationToken cancellationToken)
    {
        await WaitForFileToExistAsync(filePath, pollingIntervalMs, cancellationToken);
        var fileSize = new FileInfo(filePath).Length;
        while (true)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new TaskCanceledException();
            }
            await Task.Delay(pollingIntervalMs, cancellationToken);
            var newFileSize = new FileInfo(filePath).Length;
            if (newFileSize == fileSize)
            {
                break;
            }
            fileSize = newFileSize;
        }
    }
    /// <exception cref="TaskCanceledException" />
    internal async Task WaitForFileToExistAsync(string filePath, int pollingIntervalMs, CancellationToken cancellationToken)
    {
        while (true)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new TaskCanceledException();
            }
            if (File.Exists(filePath))
            {
                break;
            }
            await Task.Delay(pollingIntervalMs, cancellationToken);
        }
    }
