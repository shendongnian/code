    public class ItemGroup
    {
        public virtual long ItemGroupID { get; set; }
        public virtual string Name { get; set; }
    
        public virtual IList<Item> Items { get; private set; }
    }
    
    public class ItemGroupMap : ClassMap<ItemGroup>
    {
        public ItemGroupMap()
        {
            Table("ItemGroups");
            Id(x => x.ItemGroupID).GeneratedBy.Identity();
    
            Map(x => x.Name);
            HasManyToMany(x => x.ItemsInGroup)
                .Table("ItemsInGroups")
                .ParentKeyColumn("ItemGroupID")
                .ChildKeyColumn("ItemID")
                .AsList("DisplayOrder")
                .Cascade.All();
        }
    }
