    SqlTransaction transaction = null;
    SqlConnection con = null;
    // they will be used to decide whether to commit or rollback the transaction
    bool debitResult = false;
    bool creditResult = false;
    try
    {
        con = new SqlConnection(CONNECTION_STRING);
        con.Open();
        // lets begin a transaction here
        transaction = con.BeginTransaction();
        // Let us do a debit first
        using (SqlCommand cmd = con.CreateCommand())
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into Table1";   // Query here
            // assosiate this command with transaction
            cmd.Transaction = transaction;
            debitResult = cmd.ExecuteNonQuery() == 1;
        }
        // A dummy throw just to check whether the transaction are working or not
        //throw new Exception("Let see..."); // uncomment this line to see the transaction in action
        // And now do a credit
        using (SqlCommand cmd = con.CreateCommand())
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into Table2";   // Query here
            // assosiate this command with transaction
            cmd.Transaction = transaction;
            creditResult = cmd.ExecuteNonQuery() == 1;
        }
        if (debitResult && creditResult)
        {
            transaction.Commit();
        }
    }
    catch
    {
        transaction.Rollback();            
    }
    finally
    {
        con.Close();
    }
