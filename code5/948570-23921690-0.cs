    private static Expression<Func<T, bool>> constructPredicate<T>(SelectionCriteria selectionCriteria)
    {
        var predicate = PredicateBuilderEx.True<T>();
        var foo = PredicateBuilder.True<T>();
        foreach (var item in selectionCriteria.andList)
        {
            var fieldName = item.fieldName;
            var fieldValue = item.fieldValue;
            var parameter = Expression.Parameter(typeof (T), "t");
            var property = Expression.Property(parameter, fieldName);
            var value = Expression.Constant(fieldValue);
            var converted = Expression.Convert(value, property.Type);
            var comparison = Expression.Equal(property, converted);
            var lambda = Expression.Lambda<Func<T, bool>>(comparison, parameter);
            predicate = PredicateBuilderEx.And(predicate, lambda);
        }
        return predicate;
    }
