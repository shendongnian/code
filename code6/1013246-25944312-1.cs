    private MenuItem _selectedChildMenuItem;
    public MenuItem SelectedChildMenuItem
    {
        get { return _selectedChildMenuItem; }
        set
        {
            _selectedChildMenuItem = value;
            NotifyPropertyChanged("SelectedChildMenuItem");
            LoadSourcePage(); // first instantiate the page (register it to mediator)
            Mediator.NotifyColleagues(Messages.SelectedChildMenuItem, SelectedChildMenuItem); // only now notify
        }
    }
    /// <summary>
    /// Get the SourcePage and pass it to MainWindowViewModel
    /// </summary>
    private void LoadSourcePage()
    {
        if (SelectedChildMenuItem != null)
        {
            var sourceUri = (from menuItem in XDocument.Load(Messages.DataDirectory + "MenuItems.xml")
                                                    .Element("MenuItems").Elements("MenuItem").Elements("MenuItem")
                                where (int)menuItem.Parent.Attribute("Id") == CurrentParentMenuItem.Id &&
                                    (int)menuItem.Attribute("Id") == SelectedChildMenuItem.Id
                                select menuItem.Element("SourcePage").Value).FirstOrDefault();
            var relativePart = sourceUri.Substring(sourceUri.IndexOf(",,,") + 3);
            var sourcePage = System.Windows.Application.LoadComponent(new Uri(relativePart, UriKind.Relative)); // instantiation with URI
            Mediator.NotifyColleagues(Messages.SourcePage, sourcePage); // pass on
        }
    }
