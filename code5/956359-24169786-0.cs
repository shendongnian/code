    while(sqlQueryHasNotSucceeded)
    {
        try
        {
            updateCmd.ExecuteNonQuery();
            sqlQueryHasNotSucceeded = false;
        }
        catch(Exception e)
        {
            LogError(e);
            System.Threading.Thread.Sleep(1000 * 10);
        }
    }
