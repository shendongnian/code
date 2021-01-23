    public override int SaveChanges()
    {
        foreach (var changeSet in ChangeTracker.Entries())
        {
            var type = Type.GetType(changeSet.Entity.GetType().ToString());
            if (type != null)
                BaseModel Obj = (BaseModel)Convert.ChangeType(changeSet.Entity, type);
                Obj.OnSaveChanges(changeSet.Entity);
            }
        }            
        return base.SaveChanges();
    }
