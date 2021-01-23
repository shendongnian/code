    DbContext db = new DbContext();
    
    List<Item> newItems = ... // contains lots of items
    
    foreach (Item item in db.ItemSet.Where(x => !newItems.Contains(x.Id))
    {
        item.Enable = false;
    }
    
    db.SaveChanges();
