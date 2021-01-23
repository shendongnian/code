    MySqlCommand command = conn.CreateCommand();
    MySqlTransaction trans = conn.BeginTransaction();
    try
    {
        // Perform everything that you need, all queries, updates, etc.
        trans.Commit();    // this line would be executed only if no exceptions were thrown
    }
    catch
    {
        // Your error handling code
        trans.Rollback();    // rollback is only executed when exception is thrown
    }
