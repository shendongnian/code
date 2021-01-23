    public bool TryLogin(out connectionString)
    {
        // set connectionString using input controls and config settings, as you see fit
        using (var cn = new SqlConnection(connectionString))
        {
            try
            {
                cn.Open();
                cn.Close();
            }
            catch (SqlException ex)
            {
                // connection attempt failed
                return false;
            }
            // connection attempt succeeded, connection string proven to be valid
            return true;
        }
    }
