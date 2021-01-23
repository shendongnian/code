    public class DTOItem
    {
        public int ItemID { get; set; }
        public int ItemType { get; set; }
        public String SomeType {get; set;}
    }
    
    public class Item
    {
        public int itemid { get; set; }
        public string itemtype { get; set; }
        public String sometype {get; set;}
    }
    
      //Elsewhere do "Mapper.CreateMap<Item, DTOItem>();" You may need to do a more complicated CreateMap depending on how Item and DTOItem relate.
    
    public DTOItem GetItem()
    {
         
         using (var context = new MyDatabaseContext())
         {
             IQueryable<Item> itemQuery = context.Items;
             return itemQuery.Project().To<DTOItem>()
                             .Single(q => q.ItemID == 1 && q.ItemType == 1);
         }
         //the above translates to the equivalent code
         /*         
         return itemQuery.Where(q => q.itemid == 1 && q.itemtype == 1)
                         .Select(a => new ItemDTO {ItemID = a.itemid, ItemType = a.itemType, SomeType = a.sometype} )
                         .Single();
         */
    }
