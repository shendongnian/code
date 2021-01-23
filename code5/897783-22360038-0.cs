    searchFilterCollection.Add(new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false)));
    searchFilterCollection.Add(new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.HasAttachments, true)));
    searchFilterCollection.Add(new SearchFilter.Not(new SearchFilter.ContainsSubstring(ItemSchema.Subject, "FATS")));
    
    // add all to the collection...
    SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.Or, searchFilterCollection.ToArray());
