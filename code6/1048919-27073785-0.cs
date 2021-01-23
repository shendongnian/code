    string CS = "Your connection string";
    using (SqlConnection conn = new SqlConnection(CS))
    {
        SqlDataAdapter da = new SqlDataAdapter("SPName", conn);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@yourParam", SqlDbType.Int/*Your datatype*/).Value = 123;
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView2.DataSource = ds;
        GridView2.DataBind();
    }
