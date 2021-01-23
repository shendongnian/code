      public IEnumerable<Person> RetrievePeople()
      {
          using (var conn = new OracleConnection(connString))
          {
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               yield return new new Person(Convert.ToInt32(reader["id"]),reader["first_name"].ToString(),reader["last_name"].ToString());
            }
          }
      }
