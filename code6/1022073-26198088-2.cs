    public static async Task<List<SearchingItem>> GetItemsToSelect()
    {
        var getPlacesTask = GetPlaces();
        var getGroupsTask = GetGroups();
        var places = await getPlacesTask;
        //Just make the initial list from the LINQ object.
        List<SearchingItem> searchingItems = places.AsParallel().Select(place=>
            new SearchingItem() { 
                IdFromRealModel=place.Id, NameToDisplay=place.FullName, 
                ExtraInformation=place.Name, TypeOfSearchingItem=TypeOfSearchingItem.PLACE 
            }).ToList();
        var groups = await getGroupsTask;
        //build up a PLINQ IEnumerable
        var groupSearchItems = groups.AsParallel().Select(group=>
            new SearchingItem()
            {
                IdFromRealModel = group.Id, NameToDisplay = group.Name,
                ExtraInformation = group.TypeName, TypeOfSearchingItem = TypeOfSearchingItem.GROUP
            });
        
        //The building of the IEnumerable was parallel but the adding is serial.
        searchingItems.AddRange(groupSearchItems);
        return searchingItems;
    }
