    public bool Delete()
    {
        using (var context = new DbContext())
        {
            context.Set(this.GetType()).Attach(this);
            context.Entry(this).State = EntityState.Deleted;
    
            context.SaveChanges();
        }
    }
