       MySqlDataReader reader = myCommand2.ExecuteReader();
       reader.Read();
       Fname = reader.GetString(reader.GetOrdinal("FirstName"));
       Sname = reader.GetString(reader.GetOrdinal("SecondName"));
       EmailID = reader.GetString(reader.GetOrdinal("EmailID"));
       reader.Close();
