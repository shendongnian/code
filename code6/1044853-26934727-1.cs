    private DataTable LoadSMSCellProviders()
    {
        string sqlQuery = "Select * from SMSAddress";
        DataTable dt = null;
        try
        {
            dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(Utility.ConnString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        catch
        {
            if(dt != null)
                dt.Dispose();
            throw;
        }
    }
