    private void webBrowser_Navigating(object sender, NavigatingEventArgs e)
        {
            stop.IsEnabled=true;
            stop.Click += new RoutedEventHandler((object caller, System.Windows.RoutedEventArgs f) =>
            {
                stopPressed = true;
            });
            if (stopPressed == true)
                e.Cancel = true;
        }
