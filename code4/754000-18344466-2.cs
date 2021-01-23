    public override int SaveChanges()
    {
        var changeSet = ChangeTracker.Entries();
    
        if (changeSet != null)
        {
            foreach (var entry in changeSet.Where(c => c.State == EntityState.Added))
            {
                Type entityType = entry.GetType();
                //Get all the properties
                var properties = entityType.GetProperties();
                foreach(var property in properties)
                {
                    var value = property.GetValue(entry);
                    //If the property value is null, initialize with a default value
                    if(value == null)
                    {
                        //Get the default value of the property
                        var defaultValue = Activator.CreateInstance(property.PropertyType);
                        property.SetValue(defaultValue, entry, null);
                    }
                 }
            }
        }
        return base.SaveChanges();
    
    }
