    try
    {
        using(SqlCommand cmd = new SqlCommand(....))
        {
            //........
        }
    }
    catch (SqlException se)
    {
        //logging etc. 
    }
    catch (Exception ex)
    {
        //logging etc
    }
