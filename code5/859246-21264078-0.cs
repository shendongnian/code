    private bool TestConnection()
    {
    using(SqlConnection conn = new SqlConnection("connection string")
    {
        try
        {
            conn.Open()
            return true
        }
        catch(Exception ex)
        {
            //log exception
        }
        return false;
    }
    }
