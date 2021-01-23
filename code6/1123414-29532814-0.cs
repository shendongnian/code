    	public static class ToDataTableClass
    {
        public static DataTable ToDataTable<T>(this List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);
            //string tempHeaderString = "";
    
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
            foreach (var prop in props)
            {
                tb.Columns.Add(prop.Name);
                //if (prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                //{
                //    tempHeaderString = prop.Name;
                //}
                //else
                //{
                //        tb.Columns.Add(prop.Name, prop.PropertyType);
                //}
            }
    
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
    
                tb.Rows.Add(values);
            }
    
            return tb;
        }
    }
