    var entityType = entity.GetType(); // or another type source
    foreach (var prop in type.GetProperties())
    {
         if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericArguments().Any(x => x.Assembly == type.Assembly))
         {
             var navPropType = prop.PropertyType.GetGenericArguments().First(x => x.Assembly == type.Assembly);
             var keysForThisNavPropType = GetEntityType(db, navPropType);
         }
         else if (prop.PropertyType.Assembly == type.Assembly)
         {
             var keysForThisNavPropType = GetEntityType(db, prop.PropertyType);
         }
    }
