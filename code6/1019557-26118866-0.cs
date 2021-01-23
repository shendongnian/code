    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        if (settings.Contains("userData"))
        {
            string str = settings["userData"].ToString();
            if (str == "Dark")
            {
                themelistPicker1.SelectedIndex = 1;
                tblk_settings.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                tblk_theme.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                tblk_text.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                tblk_bg.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                themelistPicker1.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 80, 239));
                themelistPicker1.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 80, 239));
                LayoutRoot.Background = linear;
                App.RootFrame.Background = linear;
                ApplicationBar.BackgroundColor = Colors.Blue;
            }
            else
            {
                themelistPicker1.SelectedIndex = 0;
                tblk_settings.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                tblk_theme.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                tblk_text.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                tblk_bg.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                themelistPicker1.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                themelistPicker1.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                LayoutRoot.Background = myLinearGradientBrush;
                App.RootFrame.Background = myLinearGradientBrush;
                ApplicationBar.BackgroundColor = Color.FromArgb(255, 0, 138, 0);
            }
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
            try
            {
                if (themename == "Dark")
                {
                    tblk_settings.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                    tblk_theme.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                    tblk_text.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                    tblk_bg.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                    themelistPicker1.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 80, 239));
                    themelistPicker1.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 80, 239));
                    LayoutRoot.Background = linear;
                    App.RootFrame.Background = linear;
                    ApplicationBar.BackgroundColor = Colors.Blue;
                }
                else
                {
                    tblk_settings.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                    tblk_theme.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                    tblk_text.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                    tblk_bg.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                    themelistPicker1.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                    themelistPicker1.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                    LayoutRoot.Background = myLinearGradientBrush;
                    App.RootFrame.Background = myLinearGradientBrush;
                    ApplicationBar.BackgroundColor = Color.FromArgb(255, 0, 138, 0);
                }
            }
            catch { }
        }
    }
