    public static class DataTableExtensions
    {
        private static readonly EntityPropertyTypeMap PropertyTypeMap = new EntityPropertyTypeMap();
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
    public static class DapperExtensions
    {
        private static readonly SqlSchemaInfo SqlSchemaInfo = new SqlSchemaInfo();
        public static DataTable ConvertCollectionToUserDefinedTypeDataTable<T>(this SqlConnection connection, ICollection<T> values, string dataTableType = null)
        {
            if (dataTableType == null)
            {
                dataTableType = typeof(T).Name;
            }
            var data = values.ToDataTable();
            data.TableName = dataTableType;
            var typeColumns = SqlSchemaInfo.GetUserDefinedTypeColumns(connection, dataTableType);
            data.SetColumnsOrder(typeColumns);
            return data;
        }
        public static DynamicParameters AddTableValuedParameter(this DynamicParameters source, string parameterName, DataTable dataTable, string dataTableType = null)
        {
            if (dataTableType == null)
            {
                dataTableType = dataTable.TableName;
            }
            if (dataTableType == null)
            {
                throw new NullReferenceException(nameof(dataTableType));
            }
            source.Add(parameterName, dataTable.AsTableValuedParameter(dataTableType));
            return source;
        }
        private static void SetColumnsOrder(this DataTable table, params string[] columnNames)
        {
            int columnIndex = 0;
            foreach (var columnName in columnNames)
            {
                table.Columns[columnName].SetOrdinal(columnIndex);
                columnIndex++;
            }
        }
    }
    class EntityPropertyTypeMap
    {
        private readonly ConcurrentDictionary<Type, TypePropertyInfo> _mappings;
        public EntityPropertyTypeMap()
        {
            _mappings = new ConcurrentDictionary<Type, TypePropertyInfo>();
        }
        public TypePropertyInfo GetPropertiesForType<T>()
        {
            var type = typeof(T);
            return GetPropertiesForType(type);
        }
        private TypePropertyInfo GetPropertiesForType(Type type)
        {
            return _mappings.GetOrAdd(type, (key) => new TypePropertyInfo(type));
        }
    }
    class TypePropertyInfo
    {
        private readonly Lazy<PropertyInfo[]> _properties;
        public PropertyInfo[] Properties => _properties.Value;
        public TypePropertyInfo(Type objectType)
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
            return property.SetMethod == null || property.GetMethod.IsPrivate || HasAttributeOfType<IgnorePropertyAttribute>(property);
        }
        private static bool HasAttributeOfType<T>(MemberInfo propInfo)
        {
            return propInfo.GetCustomAttributes().Any(a => a is T);
        }
    }
    public class SqlSchemaInfo
    {
        private readonly ConcurrentDictionary<string, string[]> _udtColumns = new ConcurrentDictionary<string, string[]>();
        public string[] GetUserDefinedTypeColumns(SqlConnection connection, string dataTableType)
        {
            return _udtColumns.GetOrAdd(dataTableType, (x) =>
                connection.Query<string>($@"
                        SELECT name FROM 
                        (
	                        SELECT column_id, name
	                        FROM sys.columns
	                        WHERE object_id IN (
	                          SELECT type_table_object_id
	                          FROM sys.table_types
	                          WHERE name = '{dataTableType}'
	                        )
                        ) Result
                        ORDER BY column_id").ToArray());
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class IgnorePropertyAttribute : Attribute
    {
    }
