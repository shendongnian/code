    public static class PropertyInfoExtensions
    {
        public static string GetPropertyName<TType, TReturnType>(
            this TType @this,
            Expression<Func<TType, TReturnType>> propertyId)
        {
            return ((MemberExpression)propertyId.Body).Member.Name;
        }
    }
