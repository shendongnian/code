    string excelFile = null;
    string connectionString = null;
    OleDbConnection excelConnection = null;
    DataTable tablesInFile = null;
    int tableCount = 0;
    DataRow tableInFile = null;
    string currentTable = null;
    int tableIndex = 0;
    string[] excelTables = null;
    
    excelFile = Dts.Variables["User::ExcelFile"].Value.ToString();
    
    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFile + ";Extended Properties=Excel 8.0";
    
    excelConnection = new OleDbConnection(connectionString);
    
    excelConnection.Open();
    tablesInFile = excelConnection.GetSchema("Tables");
    
    tableCount = tablesInFile.Rows.Count;
    excelTables = new string[tableCount];
    
    foreach (DataRow tableInFile_loopVariable in tablesInFile.Rows)
    {
    tableInFile = tableInFile_loopVariable;
    currentTable = tableInFile["TABLE_NAME"].ToString();
    excelTables[tableIndex] = currentTable;
    tableIndex += 1;
    }
    }
    
    Dts.Variables["User::SheetName"].Value = excelTables[0];
    
    Dts.TaskResult = (int)ScriptResults.Success;
