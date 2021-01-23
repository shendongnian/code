         private void Login_button_click(object sender, RoutedEventArgs e)
        {
           //Code
            AppSettings settings = new AppSettings();
            settings.IsLoggedOutSetting = false;
            //Code
        }
     private void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
               //code
                AppSettings settings = new AppSettings();
                settings.IsLoggedOutSetting = false;
              //code
            }
        }      
