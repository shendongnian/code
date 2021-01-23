    foreach (var column in columns)
    {
        var property = targetExp.Type.GetProperty(
            column.name,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
        if (property == null)
            continue;
        var columnIndexExp = Expression.Constant(column.i);
        var cellExp = Expression.MakeIndex(
            paramExp, indexerInfo, new[] { columnIndexExp });
        var cellValueExp = Expression.Variable(typeof(object), "o7thPropValue");
        var convertExp = Expression.Condition(
            Expression.Equal(
                cellValueExp, 
                Expression.Constant(DBNull.Value)), 
            Expression.Default(property.PropertyType), 
            Expression.Convert(cellValueExp, property.PropertyType));
        var cellValueReadExp = Expression.Block(new[] { cellValueExp },
            Expression.Assign(cellValueExp, cellExp), convertExp);
        var bindExp = Expression.Assign(
            Expression.Property(targetExp, property), cellValueReadExp);
        exps.Add(bindExp);
    }
