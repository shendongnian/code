    public static class GenericListBuilder
    {
        public static object Build(Type type)
        {
           var obj = typeof(GenericListBuilder)
                    .GetMethod("MakeGenList", BindingFlags.Static|BindingFlags.NonPublic)
                    .MakeGenericMethod(new Type[] { type })
                    .Invoke(null, (new object[] {}));
           return obj;
        }
    
        private static List<T> MakeGenList<T>()
        {
           return new List<T>();
        }
    }
