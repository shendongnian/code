    using (SqlConnection c = new SqlConnection(AppSettings.ConnString))
    {
        using (SqlCommand cmd = new SqlCommand(sqlCmd, c))
        {
        }
    }
