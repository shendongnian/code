    ctx.SetModified(ws);
    ...
    // Real context implementation
    public void SetModified(object entity)
    {
        this.Entry(entity).State = System.Data.Entity.EntityState.Modified;
    }
