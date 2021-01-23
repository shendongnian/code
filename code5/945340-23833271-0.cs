    var winThread = new Thread(() =>
    {
        win = new MainWindow();
        win.Closed += (sender, e) => win.Dispatcher.InvokeShutdown();
        System.Windows.Threading.Dispatcher.Run();
    });
    winThread.SetApartmentState(ApartmentState.STA);
    winThread.Start();
