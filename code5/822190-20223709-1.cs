    public static IEnumerable<dynamic> SelectIntoList(string SQLselect, string connectionString, CommandType cType = CommandType.Text)
    {
      using (SqlConnection conn = new SqlConnection(connectionString))
      {
        using (SqlCommand cmd = conn.CreateCommand())
        {
          cmd.CommandType = cType;
          cmd.CommandText = SQLselect;
          conn.Open();
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.Read())  // read the first one to get the columns collection
            {
              var cols = reader.GetSchemaTable()
                           .Rows
                           .OfType<DataRow>()
                           .Select(r => r["ColumnName"]);
              do
              {
                dynamic t = new System.Dynamic.ExpandoObject();
                foreach (string col in cols)
                {
                  ((IDictionary<System.String, System.Object>)t)[col] = reader[col];
                }
                yield return t;
              } while (reader.Read());
            }
          }
          conn.Close();
        }
      }
    }
