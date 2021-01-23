    sqlconn.Open();
        for (int i = 0; i < names.Length; i++)
         {
            using (var cmd = new SqlCommand(sql, sqlconn))
            {
                cmd.Parameters.AddWithValue(names[i], values[i]);
                
                return cmd.ExecuteNonQuery();
            }
         }
