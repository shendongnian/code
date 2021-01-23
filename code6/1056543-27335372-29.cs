    public class NoTypeConverterContractResolver : DefaultContractResolver
    {
        readonly Type type;
        public NoTypeConverterContractResolver(Type type)
            : base()
        {
            if (type == null)
                throw new ArgumentNullException();
            if (type == typeof(string) || type.IsPrimitive)
                throw new ArgumentException("type == typeof(string) || type.IsPrimitive");
            this.type = type;
        }
        protected override JsonContract CreateContract(Type objectType)
        {
            if (type.IsAssignableFrom(objectType))
            {
                // Replaces JsonStringContract for the specified type.
                var contract = this.CreateObjectContract(objectType);
                return contract;
            }
            return base.CreateContract(objectType);
        }
    }
    public class GenericJsonTypeConverter<T> : TypeConverter
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        static NoTypeConverterContractResolver contractResolver;
        static NoTypeConverterContractResolver ContractResolver
        {
            get
            {
                if (contractResolver == null)
                    Interlocked.CompareExchange(ref contractResolver, new NoTypeConverterContractResolver(typeof(T)), null);
                return contractResolver;
            }
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context,
           Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context,
           CultureInfo culture, object value)
        {
            if (value is string)
            {
                using (var reader = new JsonTextReader(new StringReader((string)value)))
                {
                    var obj = JsonSerializer.Create(new JsonSerializerSettings { ContractResolver = ContractResolver }).Deserialize<T>(reader);
                    return obj;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                StringBuilder sb = new StringBuilder();
                using (StringWriter sw = new StringWriter(sb, CultureInfo.InvariantCulture))
                using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
                {
                    JsonSerializer.Create(new JsonSerializerSettings { ContractResolver = ContractResolver }).Serialize(jsonWriter, value);
                }
                return sb.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
