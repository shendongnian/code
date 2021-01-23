    private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
        if (IsolatedStorageSettings.ApplicationSettings.Contains("profile"))
           {
            HelloName.Text ="Hello"+ IsolatedStorageSettings.ApplicationSettings["profile"] as string;         
           }      
        }
