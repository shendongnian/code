    static string businessnamereturn;
    
      void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry(); 
            businessnamereturn = NavigationContext.QueryString["Businessname"];
            Locationname.Text = businessnamereturn;
        }
