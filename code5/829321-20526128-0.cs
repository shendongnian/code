    foreach (var column in columns)
    {
        var property = targetExp.Type.GetProperty(
            column.name,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
        if (property == null)
            continue;
        var columnIndexExp = Expression.Constant(column.i);
        var propertyExp = Expression.MakeIndex(
            paramExp, indexerInfo, new[] { columnIndexExp });
        var convertExp = Expression.Condition(
            Expression.Equal(
                propertyExp, 
                Expression.Constant(DBNull.Value)), 
            Expression.Default(property.PropertyType), 
            Expression.Convert(propertyExp, property.PropertyType));
        var bindExp = Expression.Assign(
            Expression.Property(targetExp, property), convertExp);
        exps.Add(bindExp);
    }
