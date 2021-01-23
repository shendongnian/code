    Application.Current.Dispatcher.Invoke(() =>
    {
        var a = Application.Current.Windows.Count;
        foreach (Window window in Application.Current.Windows)
        {
            if (window == Application.Current.MainWindow)
            {
                var windowHandle = window;
                window.Dispatcher.Invoke(windowHandle.Close);
            }
        }
    });
