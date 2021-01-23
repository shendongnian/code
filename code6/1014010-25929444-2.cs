    List<Lookup> fillCombo(string query, string column)
    {
        List<Lookup> lookups = new List<Lookup>();
        string sConstring = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(sConstring))
        using(SqlCommand cmd = new SqlCommand(query, conn))
        {
            conn.Open();
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
               while (reader.Read())
               {
                  Lookup lookupobject = new Lookup();
                  lookupobject.ID = Convert.ToInt32(reader["ID"]);
                  //if (reader["Name"] != DBNull.Value)
                  lookupobject.Name = reader[column].ToString();
                  lookups.Add(lookupobject);
                }
             }
         }        
        return lookups;
    }
