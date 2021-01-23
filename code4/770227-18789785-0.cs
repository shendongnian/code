    public static List<string> GetFruits()
    {   
        var list = new List<string>();
        OracleConnection conn1 = MyConnection.GetSourceConnection();
        conn1.Open();  
        using (OracleCommand storeFruits = new OracleCommand("MyCOMMAND", conn1))
        {
            using (OracleDataReader reader = storeFruits.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add((string)reader["TABLE_NAME"]);
                }
            }
        }
  
        return list;
    }
