    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        if (settings.Contains("userData"))
        {
            string str = settings["userData"].ToString();
            if (str == "Dark")
                themelistPicker1.SelectedIndex = 1;
            else
                themelistPicker1.SelectedIndex = 0;
        }
        base.OnNavigatedTo(e);
    }
    private void themelistPicker1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (themelistPicker1 != null && themelistPicker1.SelectedIndex > -1)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            ListPickerItem lpi = (sender as ListPicker).SelectedItem as ListPickerItem;
            string themename = lpi.Content.ToString();
            if (!settings.Contains("userData"))
                settings.Add("userData", themename);
            else
                settings["userData"] = themename;
            settings.Save();
        }
    }
