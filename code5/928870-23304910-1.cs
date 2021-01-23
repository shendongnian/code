    static void Main(string[] args)
    {
        var appthread = new Thread(new ThreadStart(() =>
        {
            app = new testWpf.App();
            app.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            app.Run();
        }));
        appthread.SetApartmentState(ApartmentState.STA);
        appthread.Start();
        Window win = new Window();
        while (true)
        {
            var key = Console.ReadKey().Key;
            // press 1 to open
            if (key == ConsoleKey.D1)
            {
                win = DispatchToApp<Window>(() =>
                {
                    var myWindow = new Window();
                    myWindow.Show();
                    return myWindow;
                });
            }
            // Press 2 to exit
            if (key == ConsoleKey.D2)
            {
                DispatchToApp(() => win.Close());
            }
        }
    }
    static TReturn DispatchToApp<TReturn>(Func<TReturn> action)
    {
        return app.Dispatcher.Invoke<TReturn>(action);
    }
    static void DispatchToApp(Action action)
    {
        app.Dispatcher.Invoke(action);        
    }
