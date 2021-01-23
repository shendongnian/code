    public static DataTable CreateDataTable<T>(ICollection<T> values)
    {
        var table = new DataTable();
            
        // Get the generic type from the collection
        var type = values.GetType().GetGenericArguments()[0];
        // Add columns base on the type's properties
        foreach (var property in type.GetProperties())
        {
            /* It is necessary to evaluate whether each property is nullable or not.
             * This is because DataTables only support null values in the form of
             * DBNull.Value.
             */
            var propertyType = property.PropertyType;
            var computedType =
                // If the type is nullable
                propertyType.IsGenericType
                    && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>) 
                // Get its underlying type
                ? propertyType.GetGenericArguments()[0]
                // If it isn't, get return the property type.
                : propertyType;
            table.Columns.Add(new DataColumn(property.Name, computedType));
        }
        // Add rows into the DataTable based off of the values
        foreach (var value in values)
        {
            var row = table.NewRow();
            foreach (var property in value.GetType().GetProperties())
            {
                // Create a container to hold the data in the value
                object data = null;
                // If the property we are adding exists...
                if (row.Table.Columns.Contains(property.Name))
                    // Then get the value of that property
                    data = value.GetType().GetProperty(property.Name).GetValue(value, null);
                // If the value is null, convert the value to DBNull
                row[property.Name] = data ?? DBNull.Value;
            }
            table.Rows.Add(row);
        }
        return table;
    }
