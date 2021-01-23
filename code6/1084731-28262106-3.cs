     while (null != (entity = GetNextEntity())
     {
        try
        {
            context.Add(entity);
            context.SaveChanges();
        }
        catch (Exception) { /* eat it */ }
     }
