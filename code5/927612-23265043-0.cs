    using (SqlConnection DBConn = new SqlConnection("connection string")
    {
        DBConn.Open();
        using (SqlTransaction DBTran = DBConn.BeginTransaction)
        {
            using (SqlCommand DBCmd = new SqlCommand("your first statement here", DBConn))
            {
                DBCmd.Transaction = DBTran;
                // set only the parameters needed for this table
                ...
                // execute statement
                DBCmd.ExecuteNonQuery();
            }
            // repeat the above block for the other tables
            ...
            // commit transaction to database
            DBTran.Commit();
        }
    }
