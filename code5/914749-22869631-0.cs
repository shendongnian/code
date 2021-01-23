     List<double> numbers = new List<double>();
     string pathConnection = "....";
     using(OleDbConnection connection = new OleDbConnection(pathConnection))
     using(OleDbCommand cmd = new OleDbCommand("Select [max t] from [DAYTIME CONFORT INDEX$]", connection))
     {
          connection.Open();
          using(OleDbDataReader reader = cmd.ExecuteReader())
          {
              while(reader.Read())
              {
                 if(!reader.IsDBNull(0))
                     numbers.Add(Convert.ToDouble(reader[0]));
              }
          }
     }
