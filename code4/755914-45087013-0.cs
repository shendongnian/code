    class InventoryItem {
    ...
       // EF code first declaration of a cross table relationship
       public virtual List<InvActivity> ItemsActivity { get; set; }
       public GetLatestActivity()
       {
           return ItemActivity?.OrderByDescending(x => x.DateEntered).SingleOrDefault();
       }
    ...
    }
