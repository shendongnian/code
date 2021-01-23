	public themes()
    {
        InitializeComponent();
        linear = new LinearGradientBrush();
        linear.StartPoint = new Point(0, 0);
        linear.EndPoint = new Point(1, 1);
        linear.GradientStops.Add(new GradientStop() { Color = Colors.Blue, Offset = 0.0 });
		inear.GradientStops.Add(new GradientStop() { Color = Colors.Cyan, Offset = 0.25 });
        linear.GradientStops.Add(new GradientStop() { Color = Colors.Blue, Offset = 0.75 });
        linear.GradientStops.Add(new GradientStop() { Color = Colors.Purple, Offset = 0.1 });
        myLinearGradientBrush = new LinearGradientBrush();
        myLinearGradientBrush.StartPoint = new Point(0.5, 0.0);
        myLinearGradientBrush.EndPoint = new Point(0.5, 1.0);
        myLinearGradientBrush.GradientStops.Add(new GradientStop() { Color = Color.FromArgb(225, 164, 196, 0), Offset = 0.0 });
        myLinearGradientBrush.GradientStops.Add(new GradientStop() { Color = Color.FromArgb(255, 96, 169, 23), Offset = 0.567 });
        myLinearGradientBrush.GradientStops.Add(new GradientStop() { Color = Color.FromArgb(255, 0, 138, 0), Offset = 1.0 });
        myLinearGradientBrush.Opacity = 50;
	}
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
