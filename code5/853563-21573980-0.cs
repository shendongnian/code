    public static class MyQueryExtensions
    {
        public static IQueryable OfType(this IQueryable source, string typeStr)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (typeStr == null)
            {
                throw new ArgumentNullException("typeStr");
            }
 
            Type type = Assembly.GetExecutingAssembly().GetType(typeStr);
            MethodInfo methodOfType = typeof(Queryable).GetMethods().First(m => m.Name == "OfType" && m.IsGenericMethod);
 
            return source.Provider.CreateQuery(Expression.Call(null, methodOfType.MakeGenericMethod(new Type[] { type }), new Expression[] { source.Expression }));
        }
    }
