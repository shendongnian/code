    CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
        () =>
        {
            Debug.WriteLine("I'm on UI thread");
            SearchProgress.IsActive = false;
            SearchButton.IsEnabled = true;
        }
    );
