    private void Application_Activated(object sender, ActivatedEventArgs e)
    {
        var activePage = (PhoneApplicationPage) RootFrame.Content;
        var pageContent = (Grid) activePage.Content;
        UsercontrolScreen childpopup = new UsercontrolScreen();
        Grid.SetRowSpan(childpopup , pageContent.RowDefinitions.Count);
        pageContent.Children.Add(childpopup );
    }
