    using (TransactionScope scope = new TransactionScope())
    {
        using (SqlConnection conn = new SqlConnection(<connectionString>))
        {
            conn.Open()
    
            try
            {
                // Do your stuff
                ...
    
                // Commit the transaction
                scope.Complete();
            }
            catch (...)
            {
                // Handle exceptions, transaction is rolled back automatically, as
                // "Complete" was not called
            }
        }
    }
