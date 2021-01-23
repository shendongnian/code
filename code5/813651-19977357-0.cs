    if (Environment.OSVersion.Version >= new Version(8, 0))
    {
        NavigationService.Navigate(new Uri("/TestPageWP8.xaml", UriKind.Relative));
    }
    else
    {
        NavigationService.Navigate(new Uri("/TestPage.xaml", UriKind.Relative));
    }
