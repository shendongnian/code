    public IQueryable<Entity> GetAll()
    {
        return GetAll(null);
    }
    
    public IQueryable<Entity> GetAll(DBContext context)
    {
        if (context == null)
        {
            using (context = new DBContext())
            {
                return GetAll(context);
            }
        }
        return context.Set<ENTITY>().Project().To<Entity>();
    }
        
