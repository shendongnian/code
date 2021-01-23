    DataTable datatable;
                datatable = new DataTable("temptable");
                datatable.Columns.Add("TBL_COL1 ");
                datatable.Columns.Add("TBL_COL2 ");
                datatable.Columns.Add("TBL_COL3");
    using (OracleBulkCopy copytothetable = new OracleBulkCopy(connectiontodb))
    {
       copytothetable .DestinationTableName = "DESTINATION_TABLE";
       foreach (DataRow row in table.Rows)
       {
          foreach (DataColumn col in datatable.Columns)
          {
             if (row[col] != DBNull.Value)
             {
                copytothetable.ColumnMappings.Add(col.ColumnName, col.ColumnName);
              }
           }
        }
        copytothetable.WriteToServer(datatable);
    }
