    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        MusicMediaElement.Source = new Uri(CurrentCountdownItem.MusicFile, UriKind.Relative);
    }
    private void beep_MediaOpened(object sender, RoutedEventArgs e)
    {
        MusicMediaElement.Play();
    }
