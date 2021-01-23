    List<T> FillListFromTable<T>(DataTable dataTable) where T : new()
    {
        List<T> list = new List<T>();
    
        foreach (DataRow row in dataTable.Rows)
        {
            T item = new T();
            foreach (PropertyInfo vr in typeof(T).GetProperties())
            {
                if (dataTable.Columns.Contains(vr.Name))
                {
                    vr.SetValue(item,
                        Convert.ChangeType(row[vr.Name], vr.PropertyType), null);
                }
            }
            list.Add(item);
        }
        return list;
    }
