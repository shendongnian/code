    using(SqlConnection connection = new SqlConnection(connectionString))
    using(SqlCommand command = connection.CreateCommand())
    {
       cmd.CommandText = @"INSERT INTO Customer(Name,Telephone,Address,[Register Date]) 
                           VALUES(@name, @tel, @address, @date)";
       // Add your parameter values with SqlParameterCollection.Add() method.
       try
       {
           connection.Open();
           command.ExecuteNonQuery();
       }
       catch(Exception ex)
       {
            //
       }
    }
