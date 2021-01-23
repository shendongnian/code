    // Fetch group member objects
    IGroupFetcher groupFetcher = (IGroupFetcher)parentGroup;
    IPagedCollection<IDirectoryObject> members = 
        groupFetcher.Members.ExecuteAsync().Result;
    // Iterate over each page keep only the Groups
    do
    {
        List<IDirectoryObject> directoryObjects = members.CurrentPage.ToList();
        foreach (IDirectoryObject member in directoryObjects)
        {
            if (member is Group)
            {
                Group group = member as Group;
                Console.WriteLine("Group: {0}", group.DisplayName);
            }
        }
        members = members.MorePagesAvailable ? 
            members = members.GetNextPageAsync().Result : null;
    } while (members != null);
