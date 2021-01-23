    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetInheritancHierarchy
            (this Type type)
        {
            for (var current = type; current != null; current = current.BaseType)
                yield return current;
        }
        public static int GetInheritanceDistance<TOther>(this Type type)
        {
            return type.GetInheritancHierarchy().TakeWhile(t => t != typeof(TOther)).Count();
        }
    }
