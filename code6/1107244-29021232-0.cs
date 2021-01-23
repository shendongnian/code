    public static class FilterByExampleHelper
    {
        public static IQueryable<T> FilterByExample<T>(this IQueryable<T> source, T example) where T : class
        {
            foreach (var property in typeof(T).GetProperties(BindingFlags.Public|BindingFlags.Instance).Where(p => p.CanRead))
            {
                ConstantExpression valueEx = null;
                var propertyType = property.PropertyType;
                if (propertyType.IsValueType)
                {
                    var value = property.GetValue(example);
                    if (value != null &&
                        !value.Equals(Activator.CreateInstance(propertyType)))
                    {
                        valueEx = Expression.Constant(value, propertyType);
                    }
                }
                if (propertyType == typeof(string))
                {
                    var value = property.GetValue(example) as string;
                    if (!string.IsNullOrEmpty(value))
                    {
                        valueEx = Expression.Constant(value);
                    }
                }
                if (valueEx == null)
                {
                    continue;
                }
    
                var parameterEx = Expression.Parameter(typeof(T)); 
                var propertyEx = Expression.Property(parameterEx, property);
                var equalsEx = Expression.Equal(propertyEx, valueEx);
                var lambdaEx = Expression.Lambda(equalsEx, parameterEx) as Expression<Func<T, bool>>;
                source = source.Where(lambdaEx);
    
            }
            return source;
        }
    }
