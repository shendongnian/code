            SqlConnection SqlConn = new SqlConnection();
            SqlCommand cmd;
            SqlConn.ConnectionString = ConfigurationManager.AppSettings["SqlConn"].ToString();
            SqlConn.Open();
            string query1 = "insert into tbl2(id,name,address) values (" + txt_id.Text + ",'" + txt_name.Text + "','" + txt_address.Text + "')";
            cmd = new SqlCommand(query1, SqlConn);
            cmd.ExecuteNonQuery();
            SqlConn.Close();
