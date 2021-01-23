    public class StringToEnumConverter<T> : ITypeConverter<string, T>, ITypeConverter<string, T?> where T : struct
        {
            public T Convert(ResolutionContext context)
            {
                T t;
                if (Enum.TryParse(source, out t))
                {
                    return t;
                }
    
                var source = (string)context.SourceValue;
                if (StringToEnumBase<T>.HasDisplayAttribute())
                {
                    var result = StringToEnumBase<T>.Parse(source);
                    return result;
                }
    
                throw new ConverterException();
            }
    
            T? ITypeConverter<string, T?>.Convert(ResolutionContext context)
            {
                var source = (string)context.SourceValue;
                if (source == null) return null;
    
                return Convert(context);
            }
        }
    
        public static class StringToEnumBase<T> where T:struct
            {
                public static T Parse(string str)
                {
                    var type = typeof (T);
        
                    var enumMembers = type.GetMembers(BindingFlags.Public | BindingFlags.Static);
        
                    var enumMembersCollection = enumMembers
                        .Select(enumMember => new
                        {
                            enumMember,
                            attributes = enumMember.GetCustomAttributes(typeof(DisplayAttribute), false)
                        })
                        .Select(t1 => new
                        {
                            t1, value = ((DisplayAttribute) t1.attributes[0]).Name
                        })
                        .Select(t1 => new Tuple<string, string>(t1.value, t1.t1.enumMember.Name))
                        .ToList();
                    var currentMember = enumMembersCollection.FirstOrDefault(item => item.Item1 == str);
                    if (currentMember == null) throw new ConverterException();
        
                    T t;
                    if (Enum.TryParse(currentMember.Item2, out t))
                    {
                        return t;
                    }
        
                    throw new ConverterException();
                }
        
                public static bool HasDisplayAttribute()
                {
                    var type = typeof (T);
                    var attributes = type.GetCustomAttributes(typeof(DisplayAttribute), false);
                    return attributes.Length > 0;
                }
            }
