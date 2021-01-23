    private async void ButtonClick(object sender, RoutedEventArgs e)
    {
        var dispatcherResult = await this.Dispatcher
                                    .RunAsync(CoreDispatcherPriority.Normal,
                                     async () =>
                {
                    await _scanner.ScanAsync();
                });
    
        // Do something after `RunAsync` completed
    } 
