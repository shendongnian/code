    public static class DataRowExtensions
    {
        public static T Cast<T>(this DataRow dataRow) where T : new()
        {
            T item = new T();
            IEnumerable<PropertyInfo> properties = item.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                                                 .Where(x => x.CanWrite);
            foreach (DataColumn column in dataRow.Table.Columns)
            {
                if (dataRow[column] == DBNull.Value)
                {
                    continue;
                }
                PropertyInfo property = properties.FirstOrDefault(x => column.ColumnName.Equals(x.Name, StringComparison.OrdinalIgnoreCase));
                if (property == null)
                {
                    continue;
                }
                try
                {
                    Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    object safeValue = (dataRow[column] == null) ? null : Convert.ChangeType(dataRow[column], t);
                    property.SetValue(item, safeValue, null);
                }
                catch
                {
                    throw new Exception($"The value '{dataRow[column]}' cannot be mapped to the property '{property.Name}'!");
                }
            }
            return item;
        }
    }
