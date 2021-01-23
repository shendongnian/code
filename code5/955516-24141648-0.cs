        public void Stop_Click(object sender, RoutedEventArgs e)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("high"))
            {
                settings.Add("high", count);
            }
            else
            {
                settings["high"] = count;
            }
            settings.Save();
        }
