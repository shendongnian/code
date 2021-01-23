       MySqlDataReader reader = myCommand2.ExecuteReader();
       reader.Read();
       Fname = reader.GetString(fnamereader.GetOrdinal("FirstName"));
       Sname = reader.GetString(snamereader.GetOrdinal("SecondName"));
       EmailID = reader.GetString(emailreader.GetOrdinal("EmailID"));
       emailreader.Close();
