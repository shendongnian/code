    button1.IsEnabled = false;
    Application.Current.Dispatcher.Invoke((Action)(() => { }),
                                           DispatcherPriority.Render);
    // some code (its take about 2-5 sec)
    button1.IsEnabled = true;
