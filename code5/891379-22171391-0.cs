     private void Application_Deactivated(object sender, DeactivatedEventArgs e)
            {
               // SettingView.LiveClient = null;
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
    
            // Code to execute when the application is closing (eg, user hit Back)
            // This code will not execute when the application is deactivated
            private void Application_Closing(object sender, ClosingEventArgs e)
            {
                IsolatedStorageSettings.ApplicationSettings.Save();
            } 
