    string[] cols = (from dc in table.Columns.Cast<DataColumn>()
                     where dc.ColumnName.Contains(prefix)
                     select dc.ColumnName)
                    .ToArray();
  
    DataView view = new DataView(table);
    DataTable selected = view.ToTable(false, cols); // false ==> include "duplicate" rows
