    int offset = 0;
    int pageSize = 50;
    bool more = true;
    ItemView view = new ItemView(pageSize, offset, OffsetBasePoint.Beginning);
    view.PropertySet = PropertySet.IdOnly;
    FindItemsResults<Item> findResults;
    List<EmailMessage> emails = new List<EmailMessage>();
    
    while(more){
        findResults = service.FindItems(WellKnownFolderName.Inbox, view);
        foreach (var item in findResults.Items){
            emails.Add((EmailMessage)item);
        }
        more = findResults.MoreAvailable;
        if (more){
            view.Offset += pageSize;
        }
    }
    PropertySet properties = (BasePropertySet.FirstClassProperties); //A PropertySet with the explicit properties you want goes here
    service.LoadPropertiesForItems(emails, properties);
