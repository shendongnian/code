    var tableName = "testTable";
    var commandText = "Select * from " + tableName;
    
    using(var conn = new SQLiteConnection(connectionString))
    {
        conn.Open();
    
        var schema = conn.GetSchema("Tables", new string[] { null, null, tableName });
        if(schema.Rows == 0) //I am assuming your original ExecuteScalar query was some kind of "If Exists" query to test for the table.
            return;
    
        using(var cmd = new SQLiteCommand(commandText, conn))
        {
            using(var reader = cmd.ExecuteReader())
            {
                  //....
            }
        }
    }
