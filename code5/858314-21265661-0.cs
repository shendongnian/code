    protected virtual bool SaveChanges(ObjectContext context)
    {
        try
        {
            int i = context.SaveChanges();
            if (i == 0)
                return false;
            return true;
        }
        catch (Exception ex)
        {
            throw new EntityContextException("SaveChanges failed.", ex);
        }
    }
