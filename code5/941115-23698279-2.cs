    using (var context = new DataBaseContext())
    {
        var dt = new DataTable();
        var conn = context.Database.Connection;
        var connectionState = conn.State;
        try
        {
            if (connectionState != ConnectionState.Open) conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GetAvailableItems";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("jobCardId", 100525));
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
        }
        catch (Exception ex)
        {
            // error handling
            throw;
        }
        finally
        {
            if (connectionState != ConnectionState.Closed) conn.Close();
        }
        return dt;
    }
