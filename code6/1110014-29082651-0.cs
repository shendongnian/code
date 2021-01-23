    var commandText =
        "DECLARE @ted varchar(100) = 'Ted A';" +
        "SELECT @ted as [Query1];" +
        "SELECT @ted as [Query2];";
    using(var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (var command = new SqlCommand(commandText, connection))
        {
            using(var reader = command.ExecuteReader())
            {
                // There are two result sets and each result set has one result.
                do
                {
                    // You will need to use the Schema Table to dynamically
                    // generate the results view
                    var schema = reader.GetSchemaTable();
                    // "ColumnName" column will have the "Query1" and "Query2"
                    var columnNameColumn = schema.Columns["ColumnName"];
                    var row = schema.Rows[0][columnNameColumn];
                    Console.WriteLine(row);
                    
                    // Now we write the results
                    while(reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0));
                    }
                }
                while(reader.NextResult());
            }
        }
    }
