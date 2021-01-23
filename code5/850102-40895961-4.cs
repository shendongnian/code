    IObjectContextAdapter contextAdapter = ((IObjectContextAdapter)this);
    MetadataWorkspace workspace = contextAdapter.ObjectContext.MetadataWorkspace;
    var items = workspace.GetItems<AssociationType>(DataSpace.CSpace);
    List<AssociationType> FKList = items == null ? null
        : items.Where(a => a.IsForeignKey).ToList();
