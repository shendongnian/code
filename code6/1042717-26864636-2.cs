    DataTable newTable = table.Clone();
    int ordinal = newTable.Columns.IndexOf("Temperature");;
    newTable.Columns.Remove("Temperature");  // remove double-column
    DataColumn tempCol = newTable.Columns.Add("Temperature"); // string
    tempCol.SetOrdinal(ordinal); 
    foreach (DataRow row in table.Rows)
    {
        DataRow newRow = newTable.Rows.Add();
        foreach(DataColumn col in newTable.Columns)
        {
            if (col == tempCol)
            {
               double temp = row.Field<double>("Temperature");
                bool negative = temp < 0;
                double abs = Math.Abs(temp);
                string newTemp = negative ? abs.ToString() + "M" : abs.ToString() + "P";
                newRow.SetField(col, newTemp);
            }
            else
                newRow.SetField(col, row[col.ColumnName]);
        }
    }  
