    var page = IsolatedStorageSettings.ApplicationSettings["qsPage"];
    var hash = IsolatedStorageSettings.ApplicationSettings["Ayath"];
    if (string.IsNullOrWhiteSpace(page.ToString()) || string.IsNullOrWhiteSpace(hash.ToString()))
    {
        MessageBox.Show("No Bookmark has been saved !");
    }
    else
    {
        NavigationService.Navigate(new Uri("/myWeb.xaml?Page=" + page + "&id=" + hash, UriKind.Relative));
    }
