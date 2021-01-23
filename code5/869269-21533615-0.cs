    {
        SqlConnection conn = new SqlConnection("connectionstring");
        try
        {
            //somework
        }
        finally
        {
            if (conn != null)
                conn.Dispose();
        }
    }
