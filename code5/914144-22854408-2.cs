    Tempdata = New SqlDataAdapter(query, SQLConnection)
    Tempdata.TableMappings.Add("Table", "Users");
    Tempdata.TableMappings.Add("Table1", "Supplier");
    Tempdata.TableMappings.Add("Table2", "MyTable");
    ...
    Tempdata.Fill(TempTable)
