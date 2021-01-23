    private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
        if (IsolatedStorageSettings.ApplicationSettings.Contains("profile"))
           {
             Player player =(Player)IsolatedStorageSettings.ApplicationSettings["profile"];         
            HelloName.Text ="Hello"+ player.FirstName;
           }      
        }
