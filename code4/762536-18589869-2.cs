        StringBuilder sbQuery = new StringBuilder();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con; //Your connection string"        
        sbQuery.Append("insert into temp (id,name,address) SELECT 1,'text1', 'text2' UNION ALL select 2,'text3', 'text4'"); // your query goes here
        cmd.CommandText = "Testing1"; // your procedure name
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@SQL",sbQuery.ToString()));
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        GridView1.DataSource = dt;
        GridView1.DataBind();  
