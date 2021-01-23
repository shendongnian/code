    int offset = 0;
    int pageSize = 50;
    boolean more = true;
    ItemView view = new ItemView(pageSize, offset, OffsetBasePoint.Beginning);
    view.PropertySet = PropertySet.IdOnly;
    FindItemsResults<Item> findResults;
    List<EmailMessage> emails = new List<EmailMessage>();
    
    while(more){
        findResults = service.FindItems(WellKnownFolderName.Inbox, view);
        foreach (var item in findResults.Items){
            emails.Add((EmailMessage)item);
        }
        more = find.MoreAvailable;
        if (more){
            view.Offset += pageSize;
        }
    }
    PropertySet properties = //A PropertySet with the explicit properties you want goes here
    service.loadPropertiesForItems(emails, properties);
