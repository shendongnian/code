    var Update = context.UpdateTables.Find(id);
    Update.Title = title;
    // Mark as changed
    context.Entry(Update).State = System.Data.Entity.EntityState.Modified;
    context.SaveChanges();
            
