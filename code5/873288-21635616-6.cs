    using System;
    namespace GN.Portal.MetaData.Enums
    {
        public static class EnumsResolver
        {
            public static Dictionary<Type,List<Type> typeToType = new Dictionary<Type,List<Type>>()
            {
                {typeof(char),new List<Type>{typeof(MyEnum1),typeof(MyEnum3),typeof(MyEnum4),typeof(MyEnum5)}},
                {typeof(int),new List<Type>{typeof(MyEnum2)}}
            };
            public static Type Resolve(Type type)
            {
                IEnumerable<Type> types = typeToType.Where(x => x.Value.Contains(type));
                return types.Any() ? types.First() : typeof(string);
            }
        }
    }
