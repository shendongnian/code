       List<int> Bays = new List<int>(); 
       using(SqlConnection connection = new SqlConnection("connString"))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT Bay FROM Garage", 
                                                                           connection))
            {
                using (SqlDataReader reader= command.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        Bays.Add(reader.GetInt32(reader.GetOrdinal("Bay")));
                    }         
                }
            } 
         }
         ..... 
       
