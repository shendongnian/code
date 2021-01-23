    SqlCommand com = new SqlCommand(UserSearch, conn);
        {   DataSet ds = com.ExecuteReader();
            if (ds.Tables.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
                conn.Close();
        }
