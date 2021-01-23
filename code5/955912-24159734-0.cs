       private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this)) return;
            String appdir = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            String mapPath = System.IO.Path.Combine(appdir, "MAP.html");
            ResultWebBrowser.Navigate(new Uri("file:///" + mapPath));
        }
