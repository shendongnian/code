    public static class PropertyExtensions
    {
        public static System.Reflection.PropertyInfo ToPropertyInfo<T, TProperty>(this Expression<Func<T, TProperty>> propExpression) where T : class
        {
            if (propExpression == null)
                throw new ArgumentNullException("propExpression");
            var expr = propExpression.Body as MemberExpression;
            if (expr == null)
                throw new ArgumentException("Property expression is not a member expression.", "propExpression");
            var propInfo = expr.Member as System.Reflection.PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException("Member expression is not for a property.", "propExpression");
            return propInfo;
        }
    }
    public static class TestIt<T> where T : class
    {
        public static void PrintProperty<TProperty>(Expression<Func<T, TProperty>> propExpression)
        {
            Console.WriteLine(propExpression.ToPropertyInfo());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TestIt<string>.PrintProperty(s => s.Length);
        }
    }
