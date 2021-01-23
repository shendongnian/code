    DataTable dt = new DataTable();
    var context = new DataBaseContext();
    var conn = context.Database.Connection;
    var connectionState = conn.State;
    try
        {
             using (context)
            {
                if (connectionState != ConnectionState.Open)
                    conn.Open();
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
                }
    catch (Exception ex)
        {
           throw ex;
        }
    finally
        {
            if (connectionState != ConnectionState.Open)
                conn.Close();
        }
    return dt;
