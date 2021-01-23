    ' create in memory datatable
    ' my choice has been to have the same datatype for all fields
    Dim sapCustomer As DataTable = New DataTable("customer")
    For Each SAPFieldName As String In SAPColMapping
      sapCustomer.Columns.Add(New DataColumn(SAPFieldName, GetType(System.String)))
    Next
    
    ' fill previous table using xml data
    For Each SapRow As XmlNode In RowList.SelectNodes("ROW")
      ... more code here to translate xml into datatable...
    Next
    
    ' create temporary table on sql server
    Using dbCmd As SqlCommand = New SqlCommand
      dbCmd.Connection = dbConn
      dbCmd.Transaction = dbTran
      dbCmd.CommandType = CommandType.Text
      dbCmd.CommandText = "create table #tempTable (your fields here)"
      dbCmd.ExecuteNonQuery
    End Using
    
    ' fill temp table
    Using sbc As SqlBulkCopy = New SqlBulkCopy(dbConn, SqlBulkCopyOptions.Default, dbTran)
      sbc.BatchSize = 1000
      ' no explicit mapping between source and destination fields
      ' because both tables have the very same field names
      sbc.DestinationTableName = "#tempTable"
      sbc.WriteToServer(sapCustomer)
    End Using
    ' handle the steps needed to copy/move the data to the final destination
    Using dbCmd As SqlCommand = New SqlCommand
      dbCmd.Connection = dbConn
      dbCmd.Transaction = dbTran
      dbCmd.CommandType = CommandType.Text
      dbCmd.CommandText = "insert into finaltable select field1, field2 from #tempTable"
      dbCmd.ExecuteNonQuery
    End Using
