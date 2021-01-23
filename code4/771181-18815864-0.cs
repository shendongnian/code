    foreach (T item in rowData)
      {
          foreach (PropertyDescriptor prop in properties)
          {
             foreach (DataColumn column in _dataGridTable.Columns)
             {
                 DataRow newRow = _dataGridTable.NewRow();
                 if (columnsHashSet.Contains(prop.Name))
                 {
                     newRow[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    break;
                 }
              }
           }
          _dataGridTable.Rows.Add(newRow); // _dataGridTable is my existing DataTable
       }
