    class Inventory
    {
        // this is inventory storage;
        // collection allows the storage to be extended later, or be displayed at once
        // (e.g., some ShowAllInventory method)
        private readonly List<Item> inventoryItems;
        public Inventory()
        {
            inventoryItems = new List<Item>
            {
                // some predefined inventory slots with default inventory items
                new Chest(),
                new Helmet(),
                new Melee(),
                new Ranged()
            };
        }
        // these properties are required, if you want to access predefined 
        // inventory slots in strongly-typed manner; they are NOT required for comparison
        public Chest ChestSlot
        {
            get { return (Chest)inventoryItems[0]; }
            set { inventoryItems[0] = value; }
        }
        public Helmet HelmetSlot
        {
            get { return (Helmet)inventoryItems[1]; }
            set { inventoryItems[1] = value; }
        }
        public Melee MeleeSlot
        {
            get { return (Melee)inventoryItems[2]; }
            set { inventoryItems[2] = value; }
        }
        public Ranged RangedSlot
        {
            get { return (Ranged)inventoryItems[3]; }
            set { inventoryItems[3] = value; }
        }
        // The comparison.
        public void Compare(Item newItem)
        {
            foreach (var item in inventoryItems)
            {
                if (item.CanCompareWith(newItem))
                {
                    item.CompareWith(newItem);
                }
            }
        }
    }
