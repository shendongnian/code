    public class TypeB
    {
    }
    public class TypeA
    {
        public TypeB B { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var nonrecursive = CreateInstance(typeof(TypeA), false) as TypeA;
            Debug.Assert(nonrecursive != null);
            Debug.Assert(nonrecursive.B == null);
            var recursive = CreateInstance(typeof(TypeA), true) as TypeA;
            Debug.Assert(recursive != null);
            Debug.Assert(recursive.B != null);
        }
        public static object CreateInstance(Type type, bool genParam) 
        {
            object instance = Activator.CreateInstance(type);
            
            if (genParam)
            {
                foreach (var propertyInfo in type.GetProperties())
                {
                    propertyInfo.SetValue(instance, CreateInstance(propertyInfo.PropertyType, genParam));
                }
            }
            return instance;
        }
    }
