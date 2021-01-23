    {
        OleDbConnection ExcelConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + @"\" + fileName + ";Extended Properties=Excel 8.0;");
        OleDbCommand ExcelCommand = new OleDbCommand();
        ExcelCommand.Connection = ExcelConnection;
        OleDbDataAdapter ExcelAdapter = new OleDbDataAdapter(ExcelCommand);
        ExcelConnection.Open();
        DataTable ExcelSheets = ExcelConnection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
        string SpreadSheetName = "[" + ExcelSheets.Rows[workSheetNumber]["TABLE_NAME"].ToString() + "]";
        DataSet ExcelDataSet = new DataSet();
        ExcelCommand.CommandText = @"SELECT * FROM " + SpreadSheetName;
        
        ExcelAdapter.Fill(ExcelDataSet);
        ExcelConnection.Close();
        return ExcelDataSet;
    }
