    MyUser user = null;
    
    using (OleDbCommand cmd = conn.CreateCommand())
    {
    
      cmd.CommandText = @"SELECT * FROM [Details] WHERE [UserName] = @Username";
      cmd.AddParameter(new OleDbParameter('@UserName', UserName));
      //Check for matches
      using (OleDbDataReader dbReader = cmd.ExecuteReader(CommandBehavior.SingleRow))
      {
        if (dbReader.HasRows)
        {
          user = new MyUser()
          {
              FirstName = (string)dbReader["FirstName"],
              Country = (string)dbReader["Country"],
              DateOfBirth = (string)dbReader["DateOfBirth"],
              //DateOfBirth = DateTime.Parse(dbReader["DateOfBirth"].ToString()),
              EmailAddress = (string)dbReader["EmailAddress"],
              Password = (string)dbReader["Password"],
              Surname = (string)dbReader["Surname"],
              Username = (string)dbReader["UserName"]
          };
        }
      }
    }  
 
    return user;
