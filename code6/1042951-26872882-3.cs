    using (SqlConnection conn = new SqlConnection("connection-string-here"))
    {
    conn.Open();
    using(SqlCommand cmd=new SqlCommand("Sp_getProducts",conn))
    {
    cmd.CommandType = CommandType.StoredProcedure; 
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataTable ds = new DataTable();
    da.Fill(ds);
    gridView.DataSource = ds;
    gridView.DataBind();
    conn.Close(); 
    }
    
    }
