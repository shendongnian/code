    private async void StartDeletingThread()
    {
        // we're in the UI thread
        ShowDeleteProcessing();
        await DeleteSelectedItem();
        // back in the UI thread
        HideDeletingProcessing();
    }
    private Task DeleteSelectedItem()
    {
        // doing the work on a Task thread
        return Task.Run(() => DeleteSelectedItem = null);
    }
