    private async void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
    {
        var connectionProfile = NetworkInformation.GetInternetConnectionProfile();
        if (connectionProfile != null && connectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
        {
            //TODO: open link
        }
        else
        {
            await new Windows.UI.Popups.MessageDialog("Internet is not available.").ShowAsync();
        }
    }
