    public void CheckForAvailableCrafts(Player player)
    {
        //Set all to false (base state)
        foreach (Item item in CraftingTableItems) {item.CanCraft = false;}
        //update those items the player can craft
        var names = CraftingList.Where(r => r.CheckForItemsNeeded(player) != null)
                                .Select(i => i.Output.ItemName);
        var items = CraftingTableItems.Where(i => names.Any(n => n == i.ItemName) );
        foreach(var item in items) {item.CanCraft = true;}
    }
