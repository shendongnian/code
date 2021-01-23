    var item = new Item();
    context.Items.Add(item);
    context.SaveChanges();
    // item.ID now contains the identifier
    item.field_one = string.Format("abc{0}", item.ID);
    // perform another save.
    context.SaveChanges();
