    using (DBContext ctx = new DBContext())
    {
        var latestAct = _item.GetLatestActivity();
        // attach the Entity object back to a usable database context
        ctx.InventoryActivity.Attach(latestAct);
    
        // your code that would make use of the latestAct's lazy loading
        // ie   latestAct.lazyLoadedChild.name = "foo";
    }
