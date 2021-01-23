     var context = new InventoryContext();
     return (from i in context.Inventories
             select new FullInventory
             {
                 InventoryID = i.InventoryID,
                 ItemModelID = i.ItemModelID,
                 ModelName = i.ItemModel.ModelName,
                 ...
                 Quantity = context.Inventories.Select(x => x.ItemModelID).Count()
             }).GroupBy(g => g.ItemModelID).ToList();
