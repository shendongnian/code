    public async Task SignOutAsync(Action onSuccess, Action onFailure)
    {
        try
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => SignOutAsync());
            onSuccess();
        }
        catch
        {
            onFailure();
        }
    }
