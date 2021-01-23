    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);
        // If the navigation can be cancelled, ask the user if they want to cancel
        if (e.IsCancelable)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to stay here?", "Confirm Navigation from Page", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                // User wants to stay here
                e.Cancel = true;
                return;
            }
        }
    }
