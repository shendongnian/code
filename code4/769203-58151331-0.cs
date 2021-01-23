    public static IQueryable<TEntity> WhereContains<TEntity>(
        this IQueryable<TEntity> query,
        string field,
        string value,
        bool throwExceptionIfNoProperty = false,
        bool throwExceptionIfNoType = false)
        where TEntity : class
    {
        PropertyInfo propertyInfo = typeof(TEntity).GetProperty(field);
        if (propertyInfo != null)
        {
            var typeCode = Type.GetTypeCode(propertyInfo.PropertyType);
            switch (typeCode)
            {
                case TypeCode.String:
                    return query.Where(String.Format("{0}.Contains(@0)", field), value);
                case TypeCode.Boolean:
                    var boolValue = (value != null
                        && (value == "1" || value.ToLower() == "true"))
                        ? true
                        : false;
                    return query.Where(String.Format("{0} == @0", field), boolValue);
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return query.Where(String.Format("{0}.ToString().Contains(@0)", field), value);
                // todo: DateTime, float, double, decimals, and other types.
                default:
                    if (throwExceptionIfNoType)
                        throw new NotSupportedException(String.Format("Type '{0}' not supported.", typeCode));
                    break;
            }
        }
        else
        {
            if (throwExceptionIfNoProperty)
                throw new NotSupportedException(String.Format("Property '{0}' not found.", propertyInfo.Name));
        }
        return query;
    }
