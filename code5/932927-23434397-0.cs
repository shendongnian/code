    struct InventoryItem
    {
       int itemId;
       int itemCount;
    }
    class Recipe
    {
       String name;
       List<InventoryItem> RequiredItems { get; set; }
    }
