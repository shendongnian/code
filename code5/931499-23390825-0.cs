    this.Dispatcher.BeginInvoke(async () =>
    {
        await Task.Delay(5000);
        startLogo.Visibility = System.Windows.Visibility.Collapsed;
        webView.Visibility = System.Windows.Visibility.Visible;
    });
