    public async virtual Task NavigateAsync(Type sourcePageType)
    {
        await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
            {
                ((Frame)Window.Current.Content).Navigate(sourcePageType);
            });
    }
