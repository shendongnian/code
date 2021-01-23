    private static void connect() {
      // static SqlConnection conn is a bad idea, local variable is much better
      // Do not forget to dispose IDisposable: using(...) {...}
      using (SqlConnection conn = new SqlConnection("<connection string>")) {
        // Do not forget to dispose IDisposable: using(...) {...}
        using (SqlCommand command = new SqlCommand("spTester", conn)) {
          // You're executing procedure, not ordinal SQL
          command.CommandType = CommandType.StoredProcedure;
          // It seems, that you should provide a parameter to your procedure:
          //TODO: Change "@ParameterName" to actual one
          command.Parameters.Add(new SqlParameter("@ParameterName", "this is tested"));
          // You don't need any result value be returned
          command.ExecuteNonQuery();
        }
      }
    }
