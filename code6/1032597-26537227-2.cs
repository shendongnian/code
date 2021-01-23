    private void appBarAddBtn_Click(object sender, EventArgs e)
    {
        string url = "/MainPage.xaml" +
            "?wrkTbx=" + System.Web.HttpUtility.UrlEncode(wrkTbx) +
            "&rstTbx=" + System.Web.HttpUtility.UrlEncode(rstTbx) +
            "&roundTbx=" + System.Web.HttpUtility.UrlEncode(roundTbx);
        NavigationService.Navigate(new Uri(url, UriKind.Relative));
    }
