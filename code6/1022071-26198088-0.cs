    public static async Task<List<SearchingItem>> GetItemsToSelect()
    {
        List<SearchingItem> searchingItems = new List<SearchingItem>();
        var getPlacesTask = GetPlaces();
        var getGroupsTask = GetGroups();
        foreach (Place place in await getPlacesTask)
        {
            searchingItems.Add(new SearchingItem() { 
                IdFromRealModel=place.Id, NameToDisplay=place.FullName, 
                ExtraInformation=place.Name, TypeOfSearchingItem=TypeOfSearchingItem.PLACE });
        }
        foreach (Group group in await getGroupsTask)
        {
            searchingItems.Add(new SearchingItem()
            {
                IdFromRealModel = group.Id, NameToDisplay = group.Name,
                ExtraInformation = group.TypeName, TypeOfSearchingItem = TypeOfSearchingItem.GROUP
            });
        }
        return searchingItems;
    }
