    var view = new FolderView(int.MaxValue)
    {
        PropertySet = new PropertySet(BasePropertySet.FirstClassProperties) { FolderSchema.DisplayName }
    };
    SearchFilter foldersearchFilter = new SearchFilter.IsGreaterThan(FolderSchema.TotalCount, 0);
    view.Traversal = FolderTraversal.Deep;
    List<Folder> searchFolders;
    try
    {
        searchFolders = new List<Folder>
                {
                    Folder.Bind(ExchangeService, WellKnownFolderName.Inbox),
                    Folder.Bind(ExchangeService, WellKnownFolderName.SentItems)
                };
    }
    catch (ServiceResponseException e) {}
    
    searchFolders.AddRange(ExchangeService.FindFolders(WellKnownFolderName.Inbox, foldersearchFilter, view).Folders);
    searchFolders.AddRange(ExchangeService.FindFolders(WellKnownFolderName.SentItems, foldersearchFilter, view).Folders);
    
    var results = new List<Item>();
    foreach (var searchFolder in searchFolders)
    {
        //Get all emails in this folder
    }
