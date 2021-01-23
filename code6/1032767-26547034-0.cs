    SearchFilter sf = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
    FindItemsResults<Item> findResults;
    ItemView view = new ItemView(100);
    do {
        findResults = service.FindItems(WellKnownFolderName.Inbox, sf, view);
        foreach (var item in findResults.Items) {
            // TODO: process the unread item as you already did
        }
        view.Offset = findResults.NextPageOffset;
    }
    while (findResults.MoreAvailable);
