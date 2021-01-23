    //button
    var appBarButton = new ApplicationBarIconButton
    {
        IconUri = new Uri("/Images/YourImage.png", UriKind.Relative),
        Text = "click me"
    };
    appBarButton.Click += new EventHandler(appBarButton_Click);
    //menu item
    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem
    {
        Text = "a menu item"
    }
    appBarMenuItem.Click += new EventHandler(appBarMenuItem_Click);
    //application bar
    //Note that this is not a variable declaration
    //'ApplicationBar' is a property of 'PhoneApplicationPage'
    ApplicationBar = new ApplicationBar();
    ApplicationBar.Buttons.Add(appBarButton);
    ApplicationBar.MenuItems.Add(appBarMenuItem);
    //the events
    private void appBarButton_Click(object sender, EventArgs e)
    {
    }
    private void appBarMenuItem_Click(object sender, EventArgs e)
    {
    }
