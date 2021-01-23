    public void SQL()
    {
        try
        {
    
        }
        catch (SqlException Ex)
        {
            SqlHandler(Ex);
        }
        catch (OdbcException Ex)
        {
            if (Ex.InnerException is SqlException) SqlHandler((SqlException)Ex.InnerException);
        }
        catch (Exception Ex)
        {
        }
    
    
    }
    void SqlHandler(SqlException Ex)
    {
        // handle
    }
