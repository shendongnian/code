        public void bindgrid()
        {
            SqlConnection con = new SqlConnection(connStr);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand(connStr, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "your sp";
            cmd.ExecuteNonQuery();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            Session["datasource"] = ds; // In case u want to store ur dataset in session and use it anywhere further
            Gridview1.DataSource = ds.Tables[0];
            Gridview1.DataBind();
        }
