    var context = new TSQL2012Entities();
    
    var table = new DataTable();
    table.Columns.Add("SomeColumn1");
    table.Columns.Add("SomeColumn2");
    table.Rows.Add(someValue11, someValue21);
    table.Rows.Add(someValue21, someValue22);
    
    var param = new SqlParameter("param1", SqlDbType.Structured);
    param.Value = table;
    param.TypeName = "[dbo].[YourTableType]";
    
    string command = "EXEC spProcName @param1";
    context.Database.ExecuteSqlCommand(command, param);
