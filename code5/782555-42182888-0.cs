    @model DataTable
    
    @{
        var columns = Model.Columns.Cast<DataColumn>().Select(c => c.ColumnName);
        var s = Model.Rows.Cast<DataRow>().Select(r => new System.Dynamic.ExpandoObject().With(columns.ToDictionary(c => c, c => r[c])));
        WebGrid grid = new WebGrid(s, rowsPerPage: 10);
      }
