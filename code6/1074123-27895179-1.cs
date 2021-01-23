    try
    {
        if (!hasSqlError)
        {
            dbwt.Commit();
        }
        else
        {
            dbwt.Rollback();
        }
        this.Close();
    }
    finally
    {
        dbwt.End();
    }
