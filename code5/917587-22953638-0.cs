    private void UserControl_KeyDown(object sender, KeyEventArgs e)
     {
         if (e.Key == Key.Escape && App.Host.Content.IsFullScreen)
         {
             App.Host.Content.IsFullScreen = True;
         }
    }
