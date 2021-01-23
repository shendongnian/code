    public static class DynamicLinqDataTableHelpers
    {
        public static DataTable ToDataTable(this IQueryable items)
        {
            Type type = items.ElementType;
            // Create the result table, and gather all properties of a type        
            DataTable table = new DataTable(type.Name);
            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            // Add the properties as columns to the datatable
            foreach (PropertyInfo prop in props)
            {
                Type propType = prop.PropertyType;
                // Is it a nullable type? Get the underlying type 
                if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    propType = Nullable.GetUnderlyingType(propType);
                }
                table.Columns.Add(prop.Name, propType);
            }
            // Add the property values as rows to the datatable
            foreach (object item in items)
            {
                var values = new object[props.Length];
                if (item != null)
                {
                    for (var i = 0; i < props.Length; i++)
                    {
                        values[i] = props[i].GetValue(item, null);
                    }
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
