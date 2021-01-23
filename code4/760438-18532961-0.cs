    var page = IsolatedStorageSettings.ApplicationSettings["qsPage"];
    var hash = IsolatedStorageSettings.ApplicationSettings["Ayath"];
    if (string.IsNullOrWhiteSpace(page) || string.IsNullOrWhiteSpace(hash))
    {
        MessageBox.Show("No Bookmark has been saved !");
    }
    else
    {
        NavigationService.Navigate(new Uri("/myWeb.xaml?Page=" + page + "&id=" + hash, UriKind.Relative));
    }
