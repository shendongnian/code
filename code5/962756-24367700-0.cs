    public MainPage()
    {
        InitializeComponent();
    
        ApplicationBar = new ApplicationBar();
    
        ApplicationBar.Mode = ApplicationBarMode.Default;
        ApplicationBar.Opacity = 1.0; 
        ApplicationBar.IsVisible = true;
        ApplicationBar.IsMenuEnabled = true;
    
        ApplicationBarMenuItem menuItem1 = new ApplicationBarMenuItem();
        menuItem1.Text = "menu item 1";
        ApplicationBar.MenuItems.Add(menuItem1);
    }
