        private object ExecuteScalar(string sql)
        {
            using (SqlConnection connection1 = new SqlConnection(connectionString))
            {
                connection1.Open();
                SqlCommand sql1 = new SqlCommand(sql, connection1);
                return sql1.ExecuteScalar();
            }
        }  
