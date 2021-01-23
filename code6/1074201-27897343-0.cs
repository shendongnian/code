    SqlConnection con = new SqlConnection(@"Data Source=ENTERKEY001;Initial Catalog=ThirdJanuaryDb;Integrated Security=True");//DataBase Connection
            con.Open();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchSp";
                cmd.Parameters.AddWithValue("@NAME", TextBox4.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            finally
            {
                con.Close();
            }
