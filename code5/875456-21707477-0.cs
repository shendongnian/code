    context.Configuration.ValidateOnSaveEnabled = false;
    // Create stub entity:
    var stock = new stock { id = model.id, description = model.desription };
    // Attach stub entity to the context:
    context.Entry(stock).State = System.Data.Entity.EntityState.Unchanged;
    // Mark one property as modified.
    context.Entry(stock).Property("desription").IsModified = true;
    context.SaveChanges();
