    DataTable dt = new DataTable();
    using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
        cnn.Open();
        using (SqlDataAdapter da = new SqlDataAdapter("MyAStoredProcedure", cnn))
        {
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);
        }
    }
    return dt;
