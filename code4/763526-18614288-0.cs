    using (SqlConnection c ...)
    using (SqlCommand cmd ...)
    {
        SqlTransaction t = c.BeginTransaction();
        try
        {
            // update database
            // try to delete file
            t.Commit();
        }
        catch (Exception ex)
        {
            // you know something failed
            // you can catch more specific exceptions and respond here
        }
    }
