    var test=new List<Item>();
    using (var ctx = new Context())
    {
        foreach (Item block in items)
        {
            ctx.items_db.Add(block);
        }
        ctx.SaveChanges();
        test = (from b in ctx.items_db
                    orderby b.index
                    select b).ToList();
    }
