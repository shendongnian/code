    // wrap in a transaction so that the entire operation 
    // either succeeds or fails as a whole
    using(var scope = new TransactionScope())
    using(var context = new DbContext()) {
        var item = new Item();
        context.Items.Add(item);
        context.SaveChanges();
        // item.ID now contains the identifier
        item.field_one = string.Format("abc{0}", item.ID);
        // perform another save.
        context.SaveChanges();
        // commit transaction
        scope.Complete();
    }
