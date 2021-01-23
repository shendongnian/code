    private async void MySomeMethod()
    {
        ContentDialog dlg = new ContentDialog()
        {
            Title = "My Content Dialog:",
            Content = "Operation completed!",
            CloseButtonText = "Ok"
        };
    
        await dlg.ShowAsync();
    }
