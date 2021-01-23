        using (SqlConnection conn = new SqlConnection(Konekcija))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.CommandText = komanda ;
            conn.Open();
            var dataReader= cmd.ExecuteReader();
            while (result.Read())
            {
              value = dataReader["amount"].ToString();
            }
          
            conn.Close();
        
        }
