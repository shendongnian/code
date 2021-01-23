    var timer = new DispatcherTimer
        (
        TimeSpan.FromMinutes(5),
        DispatcherPriority.ApplicationIdle,// Or DispatcherPriority.SystemIdle
        (s, e) => { mainWindow.Activate()}, // or something similar
        Application.Current.Dispatcher
        );
