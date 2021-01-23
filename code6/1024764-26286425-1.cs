    private async void OnButton1Click(..)
    {
        ProgressBar.IsIndeterminate = true;
        var result = await GetInvoices();
        ProgressBar.IsIndeterminate = false; // Maybe hide it, too
        // TODO: Do stuff with result
    }
