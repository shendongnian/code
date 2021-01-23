    string  filePath = "your file path";
    string excelconnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=Excel 12.0;Persist Security Info=False";
    
    OleDbConnection Connection  = new OleDbConnection(excelconnectionstring); 
    DataTable activityDataTable = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    if(activityDataTable != null)
    {
        //validate worksheet name.
        var itemsOfWorksheet = new List<SelectListItem>();
        string worksheetName;
        for (int cnt = 0; cnt < activityDataTable.Rows.Count; cnt++)
        {
            worksheetName = activityDataTable.Rows[cnt]["TABLE_NAME"].ToString();
            if (worksheetName.Contains('\''))
            {
                worksheetName = worksheetName.Replace('\'', ' ').Trim();
            }
            if (worksheetName.Trim().EndsWith("$"))
                itemsOfWorksheet.Add(new SelectListItem { Text = worksheetName.TrimEnd('$'), Value = worksheetName });
        }
    }
    // itemsOfWorksheet : all worksheet name is added in this
