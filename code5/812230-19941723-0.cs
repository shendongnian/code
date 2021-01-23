    public static class Validate
    {
        public static void AgainstNull(System.Linq.Expressions.Expression<Func<string>> expr)
        {
            var str = expr.Compile().Invoke();
            if (str == null)
            {
                string name = (expr.Body as System.Linq.Expressions.MemberExpression).Member.Name;
                throw new ArgumentNullException(name);
            }
        }
    }
