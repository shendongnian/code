    foreach (var entry in context.ChangeTracker.Entries())
    {
        foreach (var prop in entry.Entity.GetType().GetProperties())
        {
            if (prop.Name.EndsWith("Id") && 
                !prop.PropertyType.IsAssignableFrom(typeof(int)) && 
                context.Entry(entry.Entity).Property(prop.Name).IsModified)
            {
                // Log things like old value and new:
                var propEntry = context.Entry(entry.Entity).Property(prop.Name);
                var currentValue = propEntry.CurrentValue;
                var oldValue = propEntry.OriginalValue;
            }
        }
    }
