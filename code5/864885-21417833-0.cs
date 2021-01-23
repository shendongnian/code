    public MenuItem SetMenuitem(string IconSource, string Header, string IGT, string Name)
    {
        Image Icon = new Image();
        Icon.Source = new BitmapImage(new Uri(IconSource, UriKind.Relative));
        Icon.Height = 16;
        Icon.Width = 16;
        Icon.Stretch = Stretch.None;
        MenuItem MenuItem = new MenuItem();
        MenuItem.Header = Header;
        MenuItem.Icon = Icon;
        MenuItem.InputGestureText = IGT;
        MenuItem.Name = Name;
        MenuItem.Padding = new Thickness(5);
        return MenuItem;
    }
