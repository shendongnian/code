    public static int? read_int(string sql, string sconn)
    {
        try
        {
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sconn, sql))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
                else
                    return null;
            }
        }
        catch (MySqlException ex)
        {
            //Do your stuff here
            throw ex;
        }
    }
