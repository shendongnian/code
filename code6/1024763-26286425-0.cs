    private async void OnButton1Click(..)
    {
        ProgressBar.Show(); // Or set to indeterminate or whatever you want
        var result = await GetInvoices();
        ProgressBar.Hide();
        // TODO: Do stuff with result
    }
