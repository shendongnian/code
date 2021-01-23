    public static class DynamicParameterExtensions
    {
        [AttributeUsage(AttributeTargets.Property)]
        public sealed class IgnorePropertyAttribute : Attribute
        {
        }
        private class EntityPropertyTypeMap
        {
            private readonly ConcurrentDictionary<Type, EntityPropertyCollection> _mappings;
            public EntityPropertyTypeMap()
            {
                _mappings = new ConcurrentDictionary<Type, EntityPropertyCollection>();
            }
            public EntityPropertyCollection GetPropertiesForType<T>()
            {
                var type = typeof(T);
                return GetPropertiesForType(type);
            }
            private EntityPropertyCollection GetPropertiesForType(Type type)
            {
                return _mappings.GetOrAdd(type, (key) => new EntityPropertyCollection(type));
            }
        }
        private class EntityPropertyCollection
        {
            private readonly Lazy<PropertyInfo[]> _properties;
            public PropertyInfo[] Properties => _properties.Value;
            public EntityPropertyCollection(Type objectType)
            {
                _properties = new Lazy<PropertyInfo[]>(() => CreateMap(objectType), true);
            }
            private PropertyInfo[] CreateMap(Type objectType)
            {
                var typeProperties = objectType
                    .GetProperties(BindingFlags.DeclaredOnly |
                        BindingFlags.Public |
                        BindingFlags.Instance)
                    .ToArray();
                return typeProperties.Where(property => !IgnoreProperty(property)).ToArray();
            }
            private static bool IgnoreProperty(PropertyInfo property)
            {
                return property.SetMethod == null || property.GetMethod.IsPrivate|| HasAttributeOfType<IgnorePropertyAttribute>(property);
            }
            private static bool HasAttributeOfType<T>(MemberInfo propInfo)
            {
                return propInfo.GetCustomAttributes().Any(a => a is T);
            }
        }
        private static readonly EntityPropertyTypeMap PropertyTypeMap = new EntityPropertyTypeMap();
        public static void AddTable<T>(this DynamicParameters source, string parameterName, string dataTableType, ICollection<T> values)
        {
            source.Add(parameterName, values.ToDataTable().AsTableValuedParameter(dataTableType));
        }
        public static DataTable ToDataTable<T>(this ICollection<T> values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            var table = new DataTable();
            var properties = PropertyTypeMap.GetPropertiesForType<T>().Properties;
            foreach (var prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (var value in values)
            {
                var propertyCount = properties.Count();
                var propertyValues = new object[propertyCount];
                if (value != null)
                {
                    for (var i = 0; i < propertyCount; i++)
                    {
                        propertyValues[i] = properties[i].GetValue(value);
                    }
                }
                table.Rows.Add(propertyValues);
            }
            return table;
        }
    }
