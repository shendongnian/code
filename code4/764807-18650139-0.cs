    foreach (object entity in section)
    {
        context.Set(entity.GetType()).Add(entity);
        
        try
        {
            context.SaveChanges();
        }
        catch (Exception e)
        {
            //do nothing
        }
    }
