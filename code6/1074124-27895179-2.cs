    if (!hasSqlError)
    {
        dbwt.Commit();
    }
    else
    {
        dbwt.Rollback();
    }
    dbwt.End();
    this.Close();
