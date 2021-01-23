    public class MyStringComparer : IComparer<string>
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("no");
            public int Compare(string x, string y)
            {
                return string.Compare(x, y, true, culture);
            }
        }
        public static class OrderByHelper
        {
            public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
            {
                return ApplyOrder<T>(source, property, "OrderBy");
            }
            public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
            {
                return ApplyOrder<T>(source, property, "OrderByDescending");
            }
            public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property)
            {
                return ApplyOrder<T>(source, property, "ThenBy");
            }
            public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string property)
            {
                return ApplyOrder<T>(source, property, "ThenByDescending");
            }
            static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
            {
                property = property.Trim();
                string[] props = property.Split('.');
                Type type = typeof(T);
                ParameterExpression arg = Expression.Parameter(type, "x");
                Expression expr = arg;
                foreach (string prop in props)
                {
                    // use reflection (not ComponentModel) to mirror LINQ
                    PropertyInfo pi = type.GetProperty(prop);
                    expr = Expression.Property(expr, pi);
                    type = pi.PropertyType;
                }
                bool IsString = type.FullName == "System.String";
    
                Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
                MyStringComparer comparer = new MyStringComparer();
                LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);
                object result = typeof(Queryable).GetMethods().Single(
                        method => method.Name == methodName
                                && method.IsGenericMethodDefinition
                                && method.GetGenericArguments().Length == 2
                                && (IsString ? method.GetParameters().Length == 3 : method.GetParameters().Length == 2))
                        .MakeGenericMethod(typeof(T), type)
                        .Invoke(null, IsString ? new object[] { source, lambda, comparer } : new object[] { source, lambda });
                return ((IOrderedQueryable<T>)result);
            }
        }
