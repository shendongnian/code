    public static string CheckUsername()
    {
      bool usernameCheck = false;
      InitiateDatabase();//contains the root.Connection string
      MySqlCommand readCommand = rootConnection.CreateCommand();
      readCommand.CommandText = String.Format("SELECT username FROM `SCHEMA`.`USERTABLE`");
      rootConnection.Open();
      MySqlDataReader Reader = readCommand.ExecuteReader();
      while (Reader.Read())
      {
        for (int i = 0; i < Reader.FieldCount; i++)
        {
          if (Reader.GetValue(i).ToString() == USERNAME_STRING)
          {
            usernameCheck = true;
          }
        }
      }
      rootConnection.Close();
      if (usernameCheck)
      {
        return "Succes";
      }
      else
      {
        return "Wrong Username!";
      }
    }
