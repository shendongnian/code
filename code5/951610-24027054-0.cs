    public int GetUserId<TEntity>()
    {
       int userId;
       using (var cts = new MyDbContext())
       {
          userId = ctx.DbSet<TEntity>.FirstOrDefault().Select(e => e.UserId);
       }
       return userId;
    }
