    public class InventoryItem
    {
        public virtual object Id{get;set;}
        public virtual IList<InventoryItemCategory> InventoryItemCategories{get;set;}
    }
    public class InventoryItemCategoriy
    {
        public virtual InventoryItem InventoryItem{get;set;}
    }
    public class InventoryItemMap : ClassMap<InventoryItem>
    {
        public InventoryItem()
        {
            Id(x=>x.Id);
            HasMany(x=>x.InventoryItemCategories).KeyColumn("Inventory_id");
        }
    }
    public class InventoryItemCategoryMap:ClassMap<InventoryItemCategory>
    {
        public InventoryItemCategory()
        {
            References(x=>x.InventoryItem).Column("Id");
        }
    }
