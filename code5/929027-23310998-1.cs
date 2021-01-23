    public DataTable validdatatable(DataTable table)
    {
     var dt = table.Columns.AsEnumerable().Take(11);
      
     return dt.CopyToDataTable();
    }
