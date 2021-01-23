    ISession sess = factory.openSession();
    try
    {
        // do some work
        ...
        sess.Flush();
        currentTransaction.Commit();
    }
    catch (Exception e)
    {
        currentTransaction.Rollback();
        throw;
    }
    finally
    {
        sess.Close();
    }
