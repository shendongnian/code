    private void StartDeletingThread()
    {
        ShowDeleteProcessing(); // Show on top of screen "Deleting in progress..."
        Task.Run(() =>
        {
            DeleteSelectedItem();
            Application.Current.Dispatcher.BeginInvoke((Action)HideDeletingProcessing);
        });
    }
