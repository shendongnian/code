    System.Windows.Application.Current.Dispatcher.Invoke(() =>
        {
            // Update UI
        });
    or 
    System.Windows.Application.Current.MainWindow.Dispatcher.Invoke(() =>
        {
            // Update UI
        });
