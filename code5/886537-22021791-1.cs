    try 
    {
        OdbcCommand cmd = new OdbcCommand(query, conn);
        conn.ConnectionString = connString;
        conn.Open();
        cmd.ExecuteReader();
    }
    catch (OdbcException Ex) 
    {
        Debug.WriteLine(Ex.Message);
        throw Ex;
    }
    finally
    { } 
 
