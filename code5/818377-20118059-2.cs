    public static class Enum<T> where T : struct, IComparable, IFormattable, IConvertible
    {
        public static IEnumerable<T> GetValues()
        {
            return (T[])Enum.GetValues(typeof(T));
        }
    
        public static IEnumerable<string> GetNames()
        {
            return Enum.GetNames(typeof(T));
        }
        public static T Parse(string @enum)
        {
            return (T)Enum.Parse(typeof(T), @enum);
        }
        public static S GetAttribute<S>(string @enum) where S : Attribute
        {
            return (S)typeof(T).GetMember(@enum)[0]
                               .GetCustomAttributes(typeof(S), false)
                               .SingleOrDefault();
        }
    }
