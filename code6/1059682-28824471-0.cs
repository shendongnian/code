    using (TransactionScope transactionScope = new TransactionScope())
    {
        using (SqlConnection connection1 = GetConnection())
        {
            connection1.Open();
            // Use connection1
            ExecuteCommand(connection1);
            using (SqlConnection connection2 = GetConnection())
            {
                connection2.Open();
            }
            // Use connection1
            ExecuteCommand(connection1);
        }
        transactionScope.Complete();
    }
