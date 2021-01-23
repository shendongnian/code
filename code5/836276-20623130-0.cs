    private readonly SemaphoreSlim _dialogMutex = new SemaphoreSlim(1);
    public async void ShowError(string message)
    {
        await _dialogMutex.WaitAsync();
        try
        {
            var dialog = new MessageDialog(message, "Error")
            {
                CancelCommandIndex = 0,
                DefaultCommandIndex = 0,
                Options = MessageDialogOptions.None
            };
            dialog.Commands.Add(new UICommand("OK"));
            await dialog.ShowAsync();
        }
        finally
        {
            _dialogMutex.Release();
        }
    }
