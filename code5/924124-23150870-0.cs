    public static class ReflectionHelper<T>
    {
        private static readonly IEnumerable<Func<T, object>> propertyDelegates = CreateDelegates().ToArray();
        
        private static IEnumerable<Func<T, object>> CreateDelegates()
        {
            var helper = typeof(ReflectionHelper<T>).GetMethod("CreateDelegateInternal", BindingFlags.Static | BindingFlags.NonPublic);
            var properties = typeof(T).GetProperties();
            foreach(var property in properties)
            {
                var method = helper.MakeGenericMethod(typeof(T), property.PropertyType);
                yield return (Func<T, object>)method.Invoke(null, new object[] { property.GetGetMethod() });                
            }
        }
        
        private static Func<T, object> CreateDelegateInternal<T, TReturn>(MethodInfo m)
        {
            var f = (Func<T, TReturn>)Delegate.CreateDelegate(typeof(Func<T, TReturn>), m);
            return t => (object)f(t);
        }
        
        public static IEnumerable<Func<T, object>> Properties 
        {
            get { return propertyDelegates; }
        }
    }
