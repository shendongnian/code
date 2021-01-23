    public static Func<TEntity, bool> MakeFilter<TEntity>(string _propertyName, object _value) where TEntity : class
        {
            var type = typeof(TEntity);
            var property = type.GetProperty(_propertyName);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var constantValue = Expression.Constant(_value);
            var equality = Expression.Equal(propertyAccess, constantValue);
            return Expression.Lambda<Func<TEntity, bool>>(equality, parameter).Compile();
        }
