    using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cozmotestConnectionString"].ConnectionString))
    using(SqlCommand cmd = con.CreateCommand())
    {
        cmd.CommandText = "select * from entry_table Where sub = @sub";
        cmd.Parameters.Add("@sub", SqlDbType.NVarChar).Value = Request.QueryString["sub"];
        using(SqlDataAdapter da = new SqlDataAdapter(cmd, con))
        {
             DataTable dt = new DataTable();
             da.Fill(dt);
             if (dt.Rows.Count > 0)
             {
                 Label1.Text = dt.Rows[0]["sub"].ToString();
                 Label2.Text = dt.Rows[0]["body"].ToString();
             }
        } 
    }
