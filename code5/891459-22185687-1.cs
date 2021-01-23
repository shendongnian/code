    Application.Current.DispatcherUnhandledException += (s, e) =>
    {
        this.IsEnabled = false; // disable the main window
        try
        {
            var result = Task.Factory.StartNew(
                () => MessageBox.Show(
                    e.Exception.Message, "Continue?", 
                    MessageBoxButton.YesNo),
                TaskCreationOptions.LongRunning).Result; // this blocks
            if (result == MessageBoxResult.Yes)
                e.Handled = true;
        }
        finally
        {
            this.IsEnabled = true; // enable the main window
        }
    };
