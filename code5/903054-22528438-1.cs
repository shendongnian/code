    public static class ReflectionAPI
    {
        public static int GetValueOrDefault<TInput>(this TInput a, Func<TInput, int> func, int defaultValue)
            where TInput : Attribute
        //Have to restrict to struct or you get the error:
        //The type 'R' must be a non-nullable value type in order to use it as parameter 'T' in the generic type or method 'System.Nullable<T>'
        {
            if (a == null)
                return defaultValue;
            return func(a);
        }
        public static Nullable<TResult> GetValueOrDefault<TInput, TResult>(this TInput a, Func<TInput, TResult> func, Nullable<TResult> defaultValue)
            where TInput : Attribute
            where TResult : struct
        //Have to restrict to struct or you get the error:
        //The type 'R' must be a non-nullable value type in order to use it as parameter 'T' in the generic type or method 'System.Nullable<T>'
        {
            if (a == null)
                return defaultValue;
            return func(a);
        }
        //In order to constrain to a class without interfering with the overload that has a generic struct constraint
        //we need to add a parameter to the signature that is a reference type restricted to a class
        public class ClassConstraintHack<T> where T : class { }
        //The hack means we have an unused parameter in the signature
        //http://msmvps.com/blogs/jon_skeet/archive/2010/11/02/evil-code-overload-resolution-workaround.aspx
        public static TResult GetValueOrDefault<TInput, TResult>(this TInput a, Func<TInput, TResult> func, TResult defaultValue, ClassConstraintHack<TResult> ignored = default(ClassConstraintHack<TResult>))
            where TInput : Attribute
            where TResult : class
        {
            if (a == null)
                return defaultValue;
            return func(a);
        }
        //I don't go so far as to use the inheritance trick decribed in the evil code overload resolution blog, 
        //just create some overloads that take nullable types - and I will just keep adding overloads for other nullable type
        public static bool? GetValueOrDefault<TInput>(this TInput a, Func<TInput, bool?> func, bool? defaultValue)
    where TInput : Attribute
        {
            if (a == null)
                return defaultValue;
            return func(a);
        }
        public static int? GetValueOrDefault<TInput>(this TInput a, Func<TInput, int?> func, int? defaultValue)
    where TInput : Attribute
        {
            if (a == null)
                return defaultValue;
            return func(a);
        }
        public static T GetAttribute<T>(this PropertyInfo p) where T : Attribute
        {
            if (p == null)
                return null;
            return p.GetCustomAttributes(false).OfType<T>().LastOrDefault();
        }
        public static PropertyInfo GetProperty<T, R>(Expression<Func<T, R>> expression)
        {
            if (expression == null)
                return null;
            MemberExpression memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                return null;
            return memberExpression.Member as PropertyInfo;
        }
    }
