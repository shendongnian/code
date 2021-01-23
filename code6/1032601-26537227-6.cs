    private void appBarAddBtn_Click(object sender, EventArgs e)
    {
        string url = "/MainPage.xaml" +
            "?wrkTbx=" + System.Net.WebUtility.UrlEncode(wrkTbx.Text) +
            "&rstTbx=" + System.Net.WebUtility.UrlEncode(rstTbx.Text) +
            "&roundTbx=" + System.Net.WebUtility.UrlEncode(roundTbx.Text);
        NavigationService.Navigate(new Uri(url, UriKind.Relative));
    }
