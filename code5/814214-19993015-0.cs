    private void ApplyTheme()
    {          
        Application.Current.Resources.MergedDictionaries.Clear();
        var rd = new ResourceDictionary { { "Locator", locator } };
        Application.Current.Resources.MergedDictionaries.Add(rd);
        switch (theme)
        {
            case "Blue":
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/System.Windows.xaml", UriKind.RelativeOrAbsolute) });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/Telerik.Windows.Controls.GridView.xaml", UriKind.RelativeOrAbsolute) });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/Telerik.Windows.Controls.Input.xaml", UriKind.RelativeOrAbsolute) });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/Telerik.Windows.Controls.Navigation.xaml", UriKind.RelativeOrAbsolute) });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/Telerik.Windows.Controls.xaml", UriKind.RelativeOrAbsolute) });
                break;
            case "Summer":
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Telerik.Windows.Themes.Summer;component/Themes/System.Windows.xaml", UriKind.RelativeOrAbsolute) });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Telerik.Windows.Themes.Summer;component/Themes/Telerik.Windows.Controls.GridView.xaml", UriKind.RelativeOrAbsolute) });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Telerik.Windows.Themes.Summer;component/Themes/Telerik.Windows.Controls.Input.xaml", UriKind.RelativeOrAbsolute) });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Telerik.Windows.Themes.Summer;component/Themes/Telerik.Windows.Controls.Navigation.xaml", UriKind.RelativeOrAbsolute) });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Telerik.Windows.Themes.Summer;component/Themes/Telerik.Windows.Controls.xaml", UriKind.RelativeOrAbsolute) });
                break;
            }
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("Resources/Brushes.xaml", UriKind.RelativeOrAbsolute) });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("Resources/ControlTemplates.xaml", UriKind.RelativeOrAbsolute) });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("Resources/DataTemplates.xaml", UriKind.RelativeOrAbsolute) });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("Resources/Styles.xaml", UriKind.RelativeOrAbsolute) });
        }
