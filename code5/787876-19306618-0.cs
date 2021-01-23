    public class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            Schema("dbo");
            Table("Item");
            Id(x => x.IdItem, "idItem").UnsavedValue(0).GeneratedBy.Native();
            Map(x => x.IdItem, "idItem").Not.Update();
            Map(x => x.AnotherBoringField, "anotherBoringField");
            SqlInsert("EXEC [dbo].[StpInsertItem] @idItem=@p0, @anotherBoringField=@p1");
        }
    }
