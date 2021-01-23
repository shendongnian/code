    public static class ReflectionHelper
    {
        public static string PropertyName<T>(Expression<Func<T, object>> property) where T : class 
        {
            MemberExpression body = (MemberExpression)property.Body;
            return body.Member.Name;
        }
    }
