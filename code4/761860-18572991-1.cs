    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["VPO"].ConnectionString))
    {
        connection.Open();
        string sql = "SELECT DISTINCT A.account_id, A.fname, A.lname, 
                      FROM T_Test1 A WITH (NOLOCK) 
                      JOIN T_Test2 AF WITH (NOLOCK) ON A.Account_id=AF.Account_id
                      WHERE account_status = 'A' AND A.card IS NOT NULL
                        AND A.dateFrom >= '09-02-2013 00:00:00' 
                        AND A.dateFrom <= '09-30-2013 00:00:00' 
                        AND AF.code = 'INE'";
    
        using(SqlCommand command = new SqlCommand(sql, connection))
        { 
            command.CommandTimeout = 3600;             
            using (SqlDataReader reader = command.ExecuteReader())
            { 
                while (reader.Read())
                {
                     // Read the data here and do your thing...
                }
            }
        }  
    }
