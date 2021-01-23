    try 
    {
      item.Reload();
      //TODO: re-process property on underlying object here
    }
    catch (DbUpdateConcurrencyException ex) 
    {
      // process on ex.Entries[0].Entity or
      // ex.Entries[0].Entity.OriginalValues
      // if your object context is still open, you could try to re-submit after trying the 
      // entity
      ctx.Attach(ex.Entries[0].Entity);
      ctx.SaveChanges();
    }
