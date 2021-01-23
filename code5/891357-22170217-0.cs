    private void InitializeCursorMonitoring()
    {
        var point = Mouse.GetPosition(Application.Current.MainWindow);
        var timer = new System.Windows.Threading.DispatcherTimer();
        timer.Tick += delegate
        {
            Application.Current.MainWindow.CaptureMouse();
            if (point != Mouse.GetPosition(Application.Current.MainWindow))
            {
                point = Mouse.GetPosition(Application.Current.MainWindow);
                Console.WriteLine(String.Format("X:{0}  Y:{1}", point.X, point.Y));
            }
            Application.Current.MainWindow.ReleaseMouseCapture();
        };
        timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
        timer.Start();
    }
