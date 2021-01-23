    public static class ListExtensions
        {
            public static DataTable ToDataTable<T>(this List<T> list)
            {
                DataTable table = new DataTable(typeof(T).Name);
    
                //Get Properites of List Fiels
                PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
                //Create Columns as Fields of List
                foreach (PropertyInfo propertyInfo in props)
                {
                    var column = new DataColumn
                    {
                        ColumnName = propertyInfo.Name,
                        DataType = propertyInfo.PropertyType.Name.Contains("Nullable") ? typeof(string) : propertyInfo.PropertyType
                    };
    
                    table.Columns.Add(column);
                }
    
                //Fill DataTable with Rows of List
                foreach (var item in list)
                {
                    var values = new object[props.Length];
    
                    for (var i = 0; i < props.Length; i++)
                    {
                        values[i] = props[i].GetValue(item, null);
                    }
    
                    table.Rows.Add(values);
                }
    
    
                return table;
            }
        }
