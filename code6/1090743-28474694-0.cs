            con = new SqlConnection(str);
            con.Open();
            cmd = new SqlCommand("sp_comments", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@eid",Request.QueryString["id"].ToString()));
            da=new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            DataTable dtCloned = dt.Clone();
            dtCloned.Columns[3].DataType = typeof(Int32);
            foreach (DataRow row in dt.Rows)
            {
                dtCloned.ImportRow(row);
            }
            repeat.DataSource = dtCloned;
            repeat.DataBind();
