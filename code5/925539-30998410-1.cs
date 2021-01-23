    void Update(A a)
    {
       context.Entry(a).EntityState = EntityState.Modified;
       context.SaveChanges();
    }
    void Detach(A a)
    {
       context.Entry(a).EntityState = EntityState.Detached;
    }
    
