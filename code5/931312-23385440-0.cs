    private void StartDeletingThread()
    {
        ShowDeleteProcessing(); // Show on top of screen "Deleting in progress..."
        new Thread(() =>
        {
            DeleteSelectedItem();
            this.BeginInvoke(() => HideDeletingProcessing());
        }.Start();
    }
