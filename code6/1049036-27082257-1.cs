    DataTable dataTable = null;
    DataColumn dataColumn1 = null, dataColumn2 = null;
    try
    {
        dataColumn1 = new DataColumn() { ColumnName = "Handle", DataType = typeof(string) };
        dataColumn2 = new DataColumn() { ColumnName = "Nickname", DataType = typeof(string) };
        dataTable = new DataTable()
        {
            TableName = "Users",
            Columns = { dataColumn1, dataColumn2 }
        };
        usersDS.Tables.Add(dataTable);
    }
    catch
    {
        if (dataTable != null)
        {
            dataTable.Dispose();
        }
        if (dataColumn1 != null)
        {
            dataColumn1.Dispose();
        }
        if (dataColumn2 != null)
        {
            dataColumn2.Dispose();
        }
        throw;
    }
