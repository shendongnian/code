    public static class EnumExtensions
    {
        private static readonly Dictionary<Type, EnumCodePair[]> EnumCodeCache = new Dictionary<Type, EnumCodePair[]>();
        public static string GetCode(this Enum enumValue) {
            var codePairs = GetEnumCodePairs(enumValue.GetType());
            return codePairs.First(cp => Equals(cp.Enum, enumValue)).Code;
        }
        public static T ToEnum<T>(this string enumCode) {
            var codePairs = GetEnumCodePairs(typeof(T));
            return (T)codePairs.First(cp => Equals(cp.Code, enumCode)).Enum;
        }
        private static IEnumerable<EnumCodePair> GetEnumCodePairs(Type type) {
            if(!EnumCodeCache.ContainsKey(type)) {
                var enumFields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
                var codePairs = new List<EnumCodePair>();
                foreach(var enumField in enumFields) {
                    var enumValue = Enum.Parse(type, enumField.Name);
                    var codePair = new EnumCodePair {
                        Enum = enumValue
                    };
                    var attrs = enumField.GetCustomAttributes(typeof(EnumCodeAttribute), false);
                    codePair.Code = attrs.Length == 0
                                        ? enumField.Name
                                        : ((EnumCodeAttribute)attrs[0]).Code;
                    codePairs.Add(codePair);
                }
                EnumCodeCache.Add(type, codePairs.ToArray());
            }
            return EnumCodeCache[type];
        }
        class EnumCodePair
        {
            public object Enum { get; set; }
            public string Code { get; set; }
        }
    }
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumCodeAttribute : Attribute
    {
        public EnumCodeAttribute(string code) {
            Code = code;
        }
        public string Code { get; private set; }
    }
