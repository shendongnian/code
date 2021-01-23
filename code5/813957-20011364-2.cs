    public class InventoryItemRepository : IInventoryItemRepository
    {
        private readonly List<InventoryItem> inventoryItems = new List<InventoryItem>();
        . . .
        public int Get()
        {
            return inventoryItems.Count;
        }
        . . .
    }
