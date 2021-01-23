    public static IQueryable<T> FilterObjectSet<T>(IQueryable<T> inputQuery, 
                                                   Rule rule) where T : class
    {
        var par = Expression.Parameter(typeof(T));
        var prop = Expression.PropertyOrField(par, rule.field);
        var propType = prop.Member.MemberType == System.Reflection.MemberTypes.Field ? 
                                   ((FieldInfo)prop.Member).FieldType : 
                                   ((PropertyInfo)prop.Member).PropertyType);
        // I convert the data that is a string to the "correct" type here
        object data2 = Convert.ChangeType(rule.data, 
                                          propType, 
                                          CultureInfo.InvariantCulture);
        var eq = Expression.Equal(prop, Expression.Constant(data2));
        var lambda = Expression.Lambda<Func<T, bool>>(eq, par);
        return inputQuery.Where(lambda);
    }
