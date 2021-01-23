    var flags = BindingFlags.Public | BindingFlags.Instance;
    var destinationProperties = typeof(TDestination).GetProperties(flags);
    foreach (var property in destinationProperties)
    {
        var type = property.PropertyType;
        // Ignore reference property (e.g. TripReference)
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(EntityReference<>))
        {
            // ...
        }
        // Ignore navigation property (e.g. Trips)
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(EntityCollection<>))
        {
            // ...
        }
        // Ignore ID (edmscalar) property (e.g. TripID)
        if (property.GetCustomAttributes(typeof(EdmScalarPropertyAttribute), false).Any())
        {
            // ..
        }
