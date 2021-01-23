    SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adp.Fill(ds);
    if (ds.Tables[0].Rows.Count > 0)
    {
        lblClient.Enabled = true;
        lblClient.Text = Convert.ToString(ds.Tables[0].Rows[0].[0]);
        lblBranch.Text = Convert.ToString(ds.Tables[0].Rows[0].["Bname"]);
    }
    connection.Close();
