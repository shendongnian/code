    var connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\SomePath\ExcelWorkBook.xls;Extended Properties=Excel 8.0";
    using (var excelConnection = new OleDbConnection(connectionString))
    {
    	// The excel file does not need to exist, opening the connection will create the
    	// excel file for you
    	if (excelConnection.State != ConnectionState.Open) { excelConnection.Open(); }
    
    	// data is an object so it works with DBNull.Value
    	object propertyOneValue = "cool!";
    	object propertyTwoValue = "testing";
    	
    	var sqlText = "CREATE TABLE YourTableNameHere ([PropertyOne] VARCHAR(100), [PropertyTwo] INT)";
    
    	// Executing this command will create the worksheet inside of the workbook
    	// the table name will be the new worksheet name
    	using (var command = new OleDbCommand(sqlText, excelConnection)) { command.ExecuteNonQuery(); }
    
    	// Add (insert) data to the worksheet
    	var commandText = $"Insert Into YourTableNameHere ([PropertyOne], [PropertyTwo]) Values (@PropertyOne, @PropertyTwo)";
    
    	using (var command = new OleDbCommand(commandText, excelConnection))
    	{
    		// We need to allow for nulls just like we would with
    		// sql, if your data is null a DBNull.Value should be used
    		// instead of null 
    		command.Parameters.AddWithValue("@PropertyOne", propertyOneValue ?? DBNull.Value);
    		command.Parameters.AddWithValue("@PropertyTwo", propertyTwoValue ?? DBNull.Value);
    
    		command.ExecuteNonQuery();
    	}
    }
