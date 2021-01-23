    using System.Windows.Threading;
    DispatcherTimer Timer = new DispatcherTimer()
    {
        Interval = TimeSpan.FromMilliseconds(850)
    };
    Timer.Tick += (s, e) =>
    {
        Timer.Stop();
        NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));        
    };
    Timer.Start();
