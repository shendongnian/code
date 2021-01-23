    private void NavigateButton_Click(object sender, RoutedEventArgs e)
    {
        var hyperlinkButton = sender as HyperlinkButton;
        if(hyperlinkButton == null)
        {
            return;
        }
        
        ShowInBrowser(hyperlinkButton.NavigateUri);
    }
    private void ShowInBrowser(Uri url)
    {
        Microsoft.Phone.Tasks.WebBrowserTask wbt = 
            new Microsoft.Phone.Tasks.WebBrowserTask();
        wbt.Uri = url;
        wbt.Show();
    }
