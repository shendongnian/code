            string query = "select * from aspnet_Users where userName like '%@UserName%'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@UserName", TextBox1.Text);
            cmd.Connection = conn;
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
           GridView1.DataBind();
           
