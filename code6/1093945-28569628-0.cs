    public static class ReflectionHelper
    {
        public static string PropertyName<T, TReturn>(Expression<Func<T, TReturn>> property) where T : class 
        {
            MemberExpression body = (MemberExpression)property.Body;
            return body.Member.Name;
        }
    }
