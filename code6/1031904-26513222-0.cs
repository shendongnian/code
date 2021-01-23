    public static class ObjectInformation
    {
        public static string GetPropertyName<T, TProp> (Expression<Func<T, TProp>> propertyLambda)
        {
            return GetPropertyName((LambdaExpression)propertyLambda);
        }
        public static string GetPropertyName<T> (Expression<Func<T>> propertyLambda)
        {
            return GetPropertyName((LambdaExpression)propertyLambda);
        }
        private static string GetPropertyName (LambdaExpression propertyLambda)
        {
            var memberExpression = propertyLambda.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("Lambda must return a property.");
            return memberExpression.Member.Name;
        }
    }
