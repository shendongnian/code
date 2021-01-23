    public void Update<TEntity>(TEntity entity) 
    {
       using (myContext context = new myContext())
       {
         context.Set<TEntity>.Attach(entity);
         context.ChangeTracker.DetectChanges();
         context.SaveChanges(); 
       }
    }
