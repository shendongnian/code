    public async Task UpdateAsync(T user)
    {
        SetEntityStateModified(user);
        SetPropertyIsModified(user);
        await _context.SaveChangesAsync();
    }
    public virtual void SetPropertyIsModified(T user)
    {
        _context.Entry(user).Property("UserName").IsModified = false;
    }
    public virtual void SetEntityStateModified(T user)
    {
        _context.Entry(user).State = EntityState.Modified;
    }
