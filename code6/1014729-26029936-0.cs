        if (!id.HasValue)
            DbContext.People.Add(entity);
        else
        {
            var attachedEntity = DbContext.People.Find(id);
            if (attachedEntity != null && DbContext.Entry(attachedEntity).State != EntityState.Detached)
            {
                DbContext.Entry(attachedEntity).State = EntityState.Detached;
                // You may need to recursively detach child entities here if any
            }
            DbContext.People.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified; 
        }
