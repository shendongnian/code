    using(OleDbConnection connection = new OleDbConnection(connString))
    using(OleDbCommand command = connection.CreateCommand())
    {
          command.CommandText = @"insert into Persondata(FirstName,LastName,Address,Suburb,Email,Mobile) 
                                  values (?, ?, ?, ?, ?, ?)";
          //Add your parameter values with right order.
          connection.Open();
          command.ExecuteNonQuery();
    }
