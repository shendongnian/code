    if (data == null)
       throw new InvalidOperationException("Data is null");
    if (data.Columns.Count < 8)
       throw new InvalidOperationException("Invalid number of columns.");
    // Casting as DataColumn - but cast as whatever is approperiate
    if (data.Columns.Cast<DataColumn>().Any(x => x == null || x.ColumnName == null))
        throw new InvalidOperationException("Data values are missing or null.");
    var records = 
        from record in data.AsEnumerable()
        where (record.Field<string>(data.Columns[0].ColumnName).Contains(txtBC.Text) && 
               record.Field<string>(data.Columns[1].ColumnName).Contains(txtRM.Text) &&
               record.Field<string>(data.Columns[2].ColumnName).Contains(txtClient.Text) &&
               record.Field<string>(data.Columns[4].ColumnName).Contains(txtProduct.Text) &&
               record.Field<string>(data.Columns[7].ColumnName).Contains(txtSegment.Text) &&
               record.Field<string>(data.Columns[6].ColumnName).Contains(txtMonth.Text))
        select record;
    dataQuery = records.CopyToDataTable();
    dtGridPivot.DataSource = dataQuery;
