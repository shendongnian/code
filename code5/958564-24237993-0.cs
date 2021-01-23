    public void auth_st(string group)
    {
        conexiuneBD.Open();
        DataSet ds = new DataSet();
        OleDbDataAdapter adapter = new OleDbDataAdapter(string.Format("SELECT Notif FROM teams WHERE ID='{0}'",group), conexiuneBD);
        adapter.Fill(ds);
        conexiuneBD.Close();
        DataTable dt = ds.Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            listBoxCerer.Items.Add(dr["Notif"].ToString());
        }
    }
