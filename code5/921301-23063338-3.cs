    public static DataTable ListToDataTable<T>(List<T> items)
    {
    
        System.ComponentModel.PropertyDescriptorCollection properties =
        System.ComponentModel.TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        foreach (System.ComponentModel.PropertyDescriptor prop in properties)
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        foreach (T item in items)
        {
            DataRow row = table.NewRow();
            foreach (System.ComponentModel.PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            table.Rows.Add(row);
        }
        return table;
