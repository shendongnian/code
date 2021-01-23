    {
        SqlConnection conn = new SqlConnection("connectionstring");
        try
        {
            //somework
        }
        finally
        {
            if (conn != null)
                ((IDisposable)conn).Dispose(); //conn.Dispose();
        }
    }
