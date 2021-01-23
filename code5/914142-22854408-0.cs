    Tempdata = New SqlDataAdapter(querry, SQLConnection)
    Tempdata.TableMappings.Add("Table1", "Users");
    Tempdata.TableMappings.Add("Table2", "Supplier");
    ...
    Tempdata.Fill(TempTable)
