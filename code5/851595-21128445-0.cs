    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("Geom", typeof(SqlGeometry));
    
    DataRow newRow = datatable.NewRow();
    newRow["Geom"] = SqlGeometry.Point(lat, lon, 4326);
    
    datatable.Rows.Add(newRow);
    
    SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection);
    sqlBulkCopy.DestinationTableName = "MySpatialDataTable";
    sqlBulkCopy.WriteToServer(dataTable);
