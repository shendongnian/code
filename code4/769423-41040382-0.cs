    [AttributeUsage(AttributeTargets.Property)]
    public class StringToIntConvertAttribute : Attribute
    {
    }
    // tries to convert string property value to integer
    private static int GetIntFromString<TSource>(TSource src, string propertyName)
    {
        var propInfo = typeof(TSource).GetProperty(propertyName);
        var reference = (propInfo.GetValue(src) as string);
        if (reference == null)
            throw new MappingException($"Failed to map type {typeof(TSource).Name} because {propertyName} is not a string);
        // TryParse would be better
        var intVal = int.Parse(reference);
        return intVal;
    }
    public static IMappingExpression<TSource, TDestination> StringToIntMapping<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
    {
        var srcType = typeof(TSource);
        foreach (var property in srcType.GetProperties().Where(p => p.GetCustomAttributes(typeof(StringToIntConvertAttribute), inherit: false).Length > 0))
        {
            expression.ForMember(property.Name, opt => opt.MapFrom(src => GetIntFromString(src, property.Name)));
        }
        return expression;
    }
