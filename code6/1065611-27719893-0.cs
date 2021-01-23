    var activePage = (PhoneApplicationPage) RootFrame.Content;
    var pageContent = (Grid) activePage.Content;
    UsercontrolElement childpopup = new UsercontrolElement();
    Grid.SetRowSpan(childpopup , pageContent.RowDefinitions.Count);
    pageContent.Children.Add(childpopup );
