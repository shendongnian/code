    private bool _isRunning;
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        if (_isRunning)
        {
            return;
        }
        _isRunning = true;
        await Task.Run(() => SyncAllFiles());
        _isRunning = false;
        // Populate ListBox here
    }
    private void SyncAllFiles()
    {
        foreach (var file in ImageFiles)
        {
            SyncFileToLocalImage(file.FileNameNoPath);
        }
    }
