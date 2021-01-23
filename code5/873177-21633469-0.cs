    // A parameterized command text
    string CommandText = "Insert into myTable(TimeOfDay,Price,InstrumentID) values(@tod, @price, @id)";
    using(SqlConnection myConnection = new SqlConnection(......))
    {
         myConnection.Open();
         using(SqlCommand myCommand = new SqlCommand(CommandText,myConnection))
         {
             // Build the parameters before entering the loop. They are always the same
             // just the value changes, but setting the size, precision and scale allows
             // the SQL Optimizer to reuse this command
             Parameter tod = myCommand.Parameters.Add("@tod", SqlDbType.NVarChar);
             tod.Size = 50;
             Parameter price = myCommand.Parameters.Add("@price", SqlDbType.Decimal);
             price.Precision = 10;
             price.Scale = 2;
             Parameter id = myCommand.Parameters.Add("@price", SqlDbType.Int);
             
             for( ........ loop statement on your data .....) 
             {
                ... extract the parameters values ...
                myCommand.Parameters["@tod"] = tod;
                myCommand.Parameters["@price"] = price;
                myCommand.Parameters["@tod"] = insid;
                myCommand.ExecuteNonQuery();
             }
        }
    }
