        connDB.Open();
        DataSet ds = new DataSet();
        OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT Comment FROM groups WHERE ID='431'", connDB);
        adapter.Fill(ds);
        connDB.Close();
        DataTable dt = ds.Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            listBox1.Items.Add(dr["Comment"].ToString());
        }
    }
