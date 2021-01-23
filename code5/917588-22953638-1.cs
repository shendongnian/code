    private void Page_KeyDown(object sender, KeyEventArgs e)
     {
         if (e.Key == Key.Escape && App.Current.Host.Content.IsFullScreen)
            {
                App.Current.Host.Content.IsFullScreen = true;
            }
    }
