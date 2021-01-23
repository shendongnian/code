    ApplicationBarIconButton button1 = new ApplicationBarIconButton();
    button1.IconUri = new Uri("/Images/icon_search.png", UriKind.Relative);
    button1.Text = "Search";
    ApplicationBar.Buttons.Add(button1); // adding button
    button1.Click -= ShowSearch; // Adding event to button
    button1.Click += ShowSearch;
    //Removing second button
    ApplicationBar.Buttons.Remove(ApplicationBar.Buttons[1] as ApplicationBarIconButton);
