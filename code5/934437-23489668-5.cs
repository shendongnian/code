    task.ContinueWith((result) =>
    {
        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
            new Action(() =>
            {
                Files = temp;
                CommandManager.InvalidateRequerySuggested();
            }));
    });
