    void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (!e.Column.CanUserSort)
        {
            Type type = e.PropertyType;
            if (type.IsGenericType && type.IsValueType && typeof(IComparable).IsAssignableFrom(type.GetGenericArguments()[0]))
            {
                // allow nullable primitives to be sorted
                Debug.Assert(type.Name == "Nullable`1");
                e.Column.CanUserSort = true;
            }
        }
    }
