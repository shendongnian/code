    var auditExcludedProps = dbEntry.Entity.GetType()
                                           .GetProperties()
                                           .Where(p => p.GetCustomAttributes(typeof(DoNotAudit), false).Any())
                                           .Select(p => p.Name)
                                           .ToList();
    foreach (string propertyName in dbEntry.OriginalValues.PropertyNames)
    {
        var doNotAUditDefined = auditExcludedProps.Contains(propertyName);
        
        ...
    }
