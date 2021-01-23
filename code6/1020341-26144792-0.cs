    var entity1 = Expression.Parameter(typeof(Entity));
    var nameFilterExp = Expression.Call(
        Expression.Property(entity1, firstOrDefault.PropertyInfo.Name),
        typeof(string).GetMethod("Contains", new[] { typeof(string) }),
        Expression.Constant(nameFilter)
    );
    var predicate = Expression.Lambda<Func<Entity, bool>>(
        type == HandledType.Doubtful
            ? (Expression)Expression.AndAlso(Expression.Equal(Expression.Property(entity1, "IsDoubtful"), Expression.Constant(true)), nameFilterExp)
            : (Expression)nameFilterExp,
        entity1);
    entities = entities.Where(predicate);
