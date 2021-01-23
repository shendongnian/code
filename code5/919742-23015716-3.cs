    public static Expression<Func<TModel, TProperty>> GenerateModelExpression<TModel, TProperty>(PropertyInfo property)
    {
         ParameterExpression fieldName = Expression.Parameter(typeof(TModel), "m");
    
         var propertyExpr = Expression.Property(itemExpr, property.Name);
    
         return Expression.Lambda<Func<TModel, TProperty>>(propertyExpr, fieldName);
    }
