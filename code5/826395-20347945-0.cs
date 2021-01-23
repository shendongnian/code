    public DataTable AddGridRow<T>(IEnumerable<T> rowData, params String[] columnNames)
    {
      HashSet<String> columnsHashSet = new HashSet<String>(columnNames);
    
      PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
    
      foreach (T item in rowData)
      {
        foreach (PropertyDescriptor prop in properties)
        {
           DataRow newRow = _dataGridTable.NewRow();
           foreach (DataColumn column in _dataGridTable.Columns)
           {
               if (columnsHashSet.Contains(prop.Name))
               {
                 newRow[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                 break;
               }
            }
        }
      _dataGridTable.Rows.Add(newRow); // _dataGridTable is existing DataTable
    }
