    public DataTable validdatatable(DataTable table)
    {
     var dt = table.Columns.Cast<DataColumn>().Take(11);
      
     return dt.CopyToDataTable();
    }
