    public static class TypeExtensions
    {
        public static IInterface Value(this Type type)
        {
            return Activator.CreateInstance(type) as IInterface;
        }
    }
