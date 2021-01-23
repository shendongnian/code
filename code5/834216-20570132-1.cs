    public bool Delete()
    {
        using (var context = new DbContext())
        {
            context.Set(this.GetType()).Attach(this);
            context.Set(this.GetType()).Remove(this); // <-- changed line...
    
            context.SaveChanges();
        }
    }
