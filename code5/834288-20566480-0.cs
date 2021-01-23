    ApplicationBar = new ApplicationBar();
        ApplicationBar.Mode = ApplicationBarMode.Default;
        ApplicationBar.Opacity = 1.0; 
        ApplicationBar.IsVisible = true;
        ApplicationBar.IsMenuEnabled = true;
    
        ApplicationBarIconButton button1 = new ApplicationBarIconButton();
        button1.IconUri = new Uri("/Images/YourImage.png", UriKind.Relative);
        button1.Text = "button 1";
        ApplicationBar.Buttons.Add(button1);
    
        ApplicationBarMenuItem menuItem1 = new ApplicationBarMenuItem();
        menuItem1.Text = "menu item 1";
        ApplicationBar.MenuItems.Add(menuItem1);
