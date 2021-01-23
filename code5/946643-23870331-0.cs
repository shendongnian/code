        // insert code to create SqlConnection
        var dbName = string.Format("Test{0}", Environment.TickCount);
        var command = connection.CreateCommand();
        command.CommandText = string.Format("create database {0}", dbName);
        command.ExecuteNonQuery();
        command.CommandText = string.Format("use {0}", dbName);
        command.ExecuteNonQuery();
        try
        {
            command.CommandText = "create table Test (Value nvarchar(max))";
            command.ExecuteNonQuery();
            var dataTable = new DataTable();
            dataTable.Columns.Add("Value", typeof(string));
            var row = dataTable.NewRow();
            row["Value"] = "我多言語で我";
            dataTable.Rows.Add(row);
            var sqlBulkCopy = new SqlBulkCopy(connection);
            sqlBulkCopy.DestinationTableName = "Test";
            sqlBulkCopy.WriteToServer(dataTable);
            Console.WriteLine("Please check the following query:");
            Console.WriteLine(string.Format("select * from {0}..Test", dbName));
            Console.ReadKey();                
        }
        finally
        {
            command.CommandText = string.Format("drop database {0}", dbName);
            command.ExecuteNonQuery();
        }
