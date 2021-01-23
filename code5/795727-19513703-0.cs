    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class FooConverter : System.Attribute
    {
        public string Parameters;
        public Bar GetInstance(Foo foo)
        {
            var propNames = String.IsNullOrEmpty(Parameters) ? new string[] { } : Parameters.Split(',').Select(x => x.Trim());
            var parameters = foo.GetType().GetProperties().Where(x => propNames.Contains(x.Name)).Select(x => x.GetValue(foo));
            return (Bar)Activator.CreateInstance(typeof(Bar), parameters.ToArray());
        }
    }
    // extension helpers
    public static class EnumExt
    {
        public static Bar GetInstance(this BarTypeEnum value, Foo foo)
        {
            var converterAttr = value.GetAttribute<FooConverter>();
            return converterAttr != null ? converterAttr.GetInstance(foo) : null;
        }
    
        public static T GetAttribute<T>(this System.Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = fi.GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ? (T)attributes[0] : default(T);
        }   
    }
