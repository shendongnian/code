    public static DataTable CreateDataTable<T>(ICollection<T> values)
    {
        var table = new DataTable();
        // Get the generic type from the collection
        var type = values.GetType().GetGenericArguments()[0];
        foreach (var property in type.GetProperties())
        {
            // Add columns based on the type's properties
            table.Columns.Add(new DataColumn(property.Name, property.PropertyType));
        }
        foreach (var value in values)
        {
            // Then add rows from the values of each item in the collection
            var row = table.NewRow();
            foreach (var property in value.GetType().GetProperties())
            {
                row[property.Name] = value.GetType().GetProperty(property.Name);
            }
            table.Rows.Add(row);
        }
        return table;
    }
