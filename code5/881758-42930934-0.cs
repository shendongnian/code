    if (resource.Id == Guid.Empty)
    {
        this.Entry(resource).State = EntityState.Added;
        resource.Id = Guid.NewGuid();
        resource.Created = DateTime.UtcNow;
        resource.Modified = DateTime.UtcNow;
    }
    else
    {
        this.Entry(resource).State = EntityState.Modified;
        resource.Modified = DateTime.UtcNow;
    }
