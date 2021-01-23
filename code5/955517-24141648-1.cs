        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("high"))
            {
                TP.Text = settings["high"].ToString();
            }
        }
