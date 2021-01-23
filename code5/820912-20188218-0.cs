     using (SqlConnection connection = new SqlConnection(connectionString)) {
        using (SqlCommand cmd = new SqlCommand("FindMaxCustID", connection)) {
          cmd.CommandType = CommandType.StoredProcedure;
          connection .Open();
          int result =  (int)cmd.ExecuteScalar();
        }
      }
