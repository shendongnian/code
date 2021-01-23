    public static IQueryable<T> FilterObjectSet<T>(IQueryable<T> inputQuery, 
                                                   Rule rule) where T : class
    {
        Type type = typeof(T);
        var par = Expression.Parameter(type);
        Type fieldPropertyType;
        Expression fieldPropertyExpression;
        FieldInfo fieldInfo = type.GetField(rule.field);
        if (fieldInfo == null)
        {
            PropertyInfo propertyInfo = type.GetProperty(rule.field);
            if (propertyInfo == null)
            {
                throw new Exception();
            }
            fieldPropertyType = propertyInfo.PropertyType;
            fieldPropertyExpression = Expression.Property(par, propertyInfo);
        }
        else
        {
            fieldPropertyType = fieldInfo.FieldType;
            fieldPropertyExpression = Expression.Field(par, fieldInfo);
        }
        object data2 = Convert.ChangeType(rule.data, fieldPropertyType);
        var eq = Expression.Equal(fieldPropertyExpression, 
                                  Expression.Constant(data2));
        var lambda = Expression.Lambda<Func<T, bool>>(eq, par);
        return inputQuery.Where(lambda);
    }
