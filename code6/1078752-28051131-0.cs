    bool databaseUpdatedSuccessfully = false;
    
    using (var Conn = new SqlConnection(_ConnectionString))
    {
        try
        {
            Conn.Open();
            using (var ts = new System.Transactions.TransactionScope()) {
                using (SqlCommand Com = new SqlCommand(ComText, Conn))
                {
                    // db work
                }
                ts.Complete();
                databaseUpdatedSuccessfully = true;
            }
        }
        catch (Exception Ex)
        {     
            // log exception
        }
    }
    if (databaseUpdatedSuccessfully)
    {
        // process files !
    }
