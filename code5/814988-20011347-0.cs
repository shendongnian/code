    using System.Timers;
    Timer serviceStatusTimer = new Timer(5000);
    private void OnLoaded(object sender, RoutedEventArgs e) // Window loaded event
    {
        serviceStatusTimer.Elapsed += ServiceStatus;
        serviceStatusTimer.Enabled = true;
        serviceStatusTimer.Start();
    }
