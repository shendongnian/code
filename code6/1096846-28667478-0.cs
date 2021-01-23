    public DataTable GetListofProviders()
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = New SqlCommand("spGetAllProviders");
        cmd.CommandType = CommandType.StoredProcedure;
        SqlConnection cn = new SqlConnection(_dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoApplicationConnection"].ConnectionString);
        using(cn)
        {
            Try
            {
                SqlDataAdapter da = New SqlDataAdapter(cmd, cn);
                da.Fill(dt);
            }
            Catch (SqlException ex)
            {
                throw ex.Message;
            }
        }
        return dt;
    }
