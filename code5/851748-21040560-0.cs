    public static T IsWindowOpen<T>(string name = null)
        where T : Window
    {
        var windows = Application.Current.Windows.OfType<T>();
        return string.IsNullOrEmpty(name) ? windows.FirstOrDefault() : windows.FirstOrDefault(w => w.Name.Equals(name));
    }
    
    private void MenuItem1_OnClick(object sender, RoutedEventArgs e)
    {
        var window = IsWindowOpen<Window>("TestForm");
        if (window != null)
        {
            window.Focus();
        }
        else
        {
            window = new Window1 { Name = "TestForm", Title = "Welcome", };
            window1.Show();
        }
    }
