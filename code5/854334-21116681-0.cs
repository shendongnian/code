    {
        SqlConnection conn = new SqlConnection("your connection string");
        try
        {
            //your code
        }
        catch (SqlException se)
        {
            //handle particular exception first
        }
        catch (Exception ex)
        {
            //handle all other exceptions
        }
        finally
        {
            if (conn != null)
                conn.Dispose();
        }
    }
