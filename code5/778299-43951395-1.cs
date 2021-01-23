    public static class Disposable
    {
        public static void Dispose(Expression<Func<IDisposable>> expression)
        {
            var obj = expression.Compile().Invoke();
            if (obj == null)
                return;
            obj.Dispose();
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null || !IsMemberWritable(memberExpression.Member))
                return;
            var nullExpression = Expression.Constant(null, memberExpression.Type);
            var assignExpression = Expression.Assign(memberExpression, nullExpression);
            var lambdaExpression = Expression.Lambda<Action>(assignExpression);
            var action = lambdaExpression.Compile();
            action.Invoke();
        }
        private static bool IsMemberWritable(MemberInfo memberInfo)
        {
            var fieldInfo = memberInfo as FieldInfo;
            if (fieldInfo != null)
                return !fieldInfo.IsInitOnly && !fieldInfo.IsLiteral;
            var propertyInfo = memberInfo as PropertyInfo;
            if (propertyInfo != null)
                return propertyInfo.CanWrite;
            return true;
        }
    }
