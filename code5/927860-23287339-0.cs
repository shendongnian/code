    private void ShowAd(object sender, AdLoadedEventArgs e)
    {
        AdDuplexAd.Visibility = Visibility.Visible;
    }
    private void HideAd(object sender, AdLoadingErrorEventArgs e)
    {
        AdDuplexAd.Visibility = Visibility.Collapsed;
    }
