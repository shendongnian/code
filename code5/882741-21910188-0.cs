    using ( SqlConnection conn = new SqlConnection( . . . ) ) {
        using ( SqlTransaction tran = new conn.BeginTransaction() ) {
            try {
                // Data processing operation #1
                using ( SqlCommand command = new SqlCommand( ". . .", conn, tran ) {
                    // Your processing code here
                }
                // Repeat the pattern used for Data Processing Operation #1 for all other operations
                // Commit the transaction if everything completed without error.
                tran.Commit();
            } catch ( SqlException ) {
                // An error occurred.  Roll the transaction back.
                tran.Rollback();
                // Other error handling code if needed.
            }
        }
    }
