    if(IsolatedStorageSettings.ApplicationSettings.Contains("qsPage") && IsolatedStorageSettings.ApplicationSettings.Contains("Ayath"))
    {
      var page = IsolatedStorageSettings.ApplicationSettings["qsPage"];
      var hash = IsolatedStorageSettings.ApplicationSettings["Ayath"];
      if (page == null && hash == null)
    // or if i use if (page == null || hash == null)
    {    
     MessageBox.Show("No Bookmark has been saved !");
    }
    else
    {
     NavigationService.Navigate(new Uri("/myWeb.xaml?Page=" + page + "&id=" + hash, UriKind.Relative));
    }
    }
    
   
