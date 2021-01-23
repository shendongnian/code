    var context = new MyContext();
    
    using (var transaction = new TransactionScope())
    {
        MyItem item = new MyItem();
        context.Items.Add(item);
        context.SaveChanges();
    
        item.Name = "Edited name";
        context.SaveChanges();
    
        transaction.Complete();
    }
