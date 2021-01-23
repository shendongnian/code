      public IEnumerable FillCombo()
      {
            SqlConnection conn = new SqlConnection(connstring);
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader read;
            conn.Open();
            read = command.ExecuteReader();
            try
            {
                while (read.Read())
                {
                    yield return read.GetString(1);
                }
            }
            finally
            {
                read.close();
                conn.close();
            }
        }
