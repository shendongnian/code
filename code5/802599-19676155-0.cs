    this.MyCvs.SortDescriptions.Clear();
    
    this.MyCvs.GroupDescriptions.Add(new PropertyGroupDescription("ParentId"));
    
    this.FilteredMessages.SortDescriptions.Add(new SortDescription("ParentId", ListSortDirection.Ascending));
    this.FilteredMessages.SortDescriptions.Add(new SortDescription("SendTime", ListSortDirection.Ascending));
