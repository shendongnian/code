    ...
    OdbcDataAdapter d;
    DataTable dt;
    d = new OdbcDataAdapter(cmd);
    d.Fill(dt);
    ... 
    foreach (DataRow row in dt.Rows)
    {
       foreach (DataColumn column in dt.Columns)
       { // fill the column header for the first time by column.ColumnName.
       }
       foreach (DataColumn column in dt.Columns)
       { // fill the colum values using row[column] combination.
       }
    }
