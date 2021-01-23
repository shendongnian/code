    using (SqlCeConnection con = new SqlCeConnection(strConn))
        {
           try
            {
               con.Open();
               using (SqlCeCommand cmd = new SqlCeCommand("insert into Table (column1,Column2)          values         (@Val1, @val2)",con))
                {
                  cmd.Parameters.AddWithValue("@Val1", value1);
                  cmd.Parameters.AddWithValue("@Val2", value2);
                  cmd.CommandType = System.Data.CommandType.Text;
                  cmd.ExecuteNonQuery();
                }
               con.Close();
             } catch (Exception ex){ //handle any exception here}
        }
