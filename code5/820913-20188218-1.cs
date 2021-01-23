     using (SqlConnection connection = new SqlConnection(connectionString)) {
        using (SqlCommand cmd = new SqlCommand("FindMaxCustID", connection)) {
          cmd.CommandType = CommandType.StoredProcedure;
          connection .Open();
          var result =  cmd.ExecuteScalar(); // you'll get the first cell on the first row. Cast to the correct type
        }
      }
