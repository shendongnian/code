    public class ItemMap : ClassMap<Item>
    {
        public LibraryMap()
        {
             // table, id, other properties
             ...
             HasManyToMany(x => x.Ranges)
                .Table("itr_RangeItemsAssoc")
                .ParentKeyColumn("itr_ItemRangeKey") // not itm_Key
                .ChildKeyColumn("itr_ItemsKey")
                .Cascade.SaveUpdate()
                .LazyLoad();
