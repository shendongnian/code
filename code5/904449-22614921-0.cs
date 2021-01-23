    SearchFilter.SearchFilterCollection searchFilterCollection = new SearchFilter.SearchFilterCollection(LogicalOperator.And);
    searchFilterCollection.Add(new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
    searchFilterCollection.Add(new SearchFilter.IsEqualTo(EmailMessageSchema.HasAttachments, true));
    searchFilterCollection.Add(new SearchFilter.Not(new SearchFilter.ContainsSubstring(EmailMessageSchema.Subject, "FATS")));
    searchFilterCollection.Add(new SearchFilter.Not(new SearchFilter.ContainsSubstring(EmailMessageSchema.Subject, "Assignment")));
    searchFilterCollection.Add(new SearchFilter.Not(new SearchFilter.ContainsSubstring(EmailMessageSchema.Subject, "Sandbox: Assignment")));
    
    FindItemsResults<Item> results = service.FindItems(WellKnownFolderName.Inbox, searchFilterCollection, new ItemView(100));
