    string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
    var option = new TransactionOptions
    {
         IsolationLevel = IsolationLevel.ReadCommitted,
         Timeout = TimeSpan.FromSeconds(60)
    };
    using (var scopeOuter = new TransactionScope(TransactionScopeOption.Required, option))
    {
        using (var conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText="INSERT INTO Data(Code, FirstName)VALUES('A-100','Mr.A')";
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        using (var scopeInner = new TransactionScope(TransactionScopeOption.Required, option))
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText="INSERT INTO Data(Code, FirstName) VALUES('B-100','Mr.B')";
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            scopeInner.Complete();
        }
        scopeOuter.Complete();
    }
