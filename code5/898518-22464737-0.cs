    ItemView view = new ItemView(10);
    // Only look for appointments
    SearchFilter searchFilter = new SearchFilter.IsEqualTo(ItemSchema.ItemClass, "IPM.Appointment");
    // Look for items in the DeletedItems folder
    FindItemsResults<Item> results = service.FindItems(WellKnownFolderName.DeletedItems, searchFilter, view);
    // Move each of the deleted items back to the calendar
    List<ItemId> ItemsToMove = new List<ItemId>();
    foreach (Item item in results)
    {
        ItemsToMove.Add(item.Id);
    }
    service.MoveItems(ItemsToMove, WellKnownFolderName.Calendar);
