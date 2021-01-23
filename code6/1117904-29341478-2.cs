    public static class DynamicLinqDataTableHelpers
    {
        public static DataTable ToDataTable(this IEnumerable items)
        {
            // Create the result table, and gather all properties of a type        
            DataTable table = new DataTable();
            PropertyInfo[] props = null;
            // Add the property values as rows to the datatable
            foreach (object item in items)
            {
                if (props == null && item != null)
                {
                    Type type = item.GetType();
                    props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
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
                }
                // When the column headers are defined, all the rows have
                // their number of columns "fixed" to the right number
                var values = new object[props != null ? props.Length : 0];
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
