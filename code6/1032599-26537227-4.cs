    private void appBarAddBtn_Click(object sender, EventArgs e)
    {
        string url = "/MainPage.xaml" +
            "?wrkTbx=" + System.Net.WebUtility.UrlEncode(wrkTbx) +
            "&rstTbx=" + System.Net.WebUtility.UrlEncode(rstTbx) +
            "&roundTbx=" + System.Net.WebUtility.UrlEncode(roundTbx);
        NavigationService.Navigate(new Uri(url, UriKind.Relative));
    }
