     while (null != (entity = GetNextEntity())
     {
        if (entity.IsValid())
        {
            context.Add(entity);
            context.SaveChanges();
        }
     }
