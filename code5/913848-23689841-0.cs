    void MethodRunningInAppDomainB(SqlConnection connectionFromAppDomainA, SqlTransaction transactionFromAppDomainA)
    {
        using (var cmd = connectionFromAppDomainA.CreateCommand())
        {
            cmd.CommandText = "this is my query";
            cmd.Transaction = transaction;
            cmd.Parameters.Add(...);
            ...
             
            cmd.ExecuteNonQuery();
        }
    }
