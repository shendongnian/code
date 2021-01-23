    private static void connect() {
      // static SqlConnection conn is a bad idea, local variable is much better
      // Do not forget to dispose IDisposable: using(...) {...}
      using (SqlConnection conn = new SqlConnection("<connection string>")) {
        // Do not forget to dispose IDisposable: using(...) {...}
        using (SqlCommand command = new SqlCommand("spTester 'this is tested'", conn)) {
          // You're executing procedure, not ordinal SQL
          command.CommandType = CommandType.StoredProcedure;
          // You don't need any result value be returned
          command.ExecuteNonQuery();
        }
      }
    }
