    public static DataTable PropertiesToDataTable<T>(this IEnumerable<T> source)
    {
        DataTable dt = new DataTable();
        var props = TypeDescriptor.GetProperties(typeof(T));    
        foreach (PropertyDescriptor prop in props)
        {
            DataColumn dc = dt.Columns.Add(prop.Name, prop.PropertyType);
            dc.Caption = prop.DisplayName;
            dc.ReadOnly = prop.IsReadOnly;
        }    
        foreach (T item in source)
        {
            DataRow dr = dt.NewRow();
            foreach (PropertyDescriptor prop in props)
            {
                dr[prop.Name] = prop.GetValue(item);
                dt.Rows.Add(dr);
            }
         return dt;
    }
