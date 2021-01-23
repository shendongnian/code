        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\revision.accdb");
        OleDbConnection con2 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\revision2.accdb");
        OleDbCommand cmd = new OleDbCommand("select * From batch", con);
        OleDbCommand cmd2 = new OleDbCommand("select * From batches", con2);
        con.Open();
        con2.Open();
        OleDbDataReader dr = cmd.ExecuteReader();
        OleDbDataReader dr2 = cmd2.ExecuteReader();
        DataTable tbl1 = new DataTable();
        tbl1.Load(dr);
        DataTable tbl2 = new DataTable();
        tbl1.Load(dr2);
        dataGridView1.DataKeyNames = new string[] { "batch_no" };
        dataGridView1.DataSource = tbl1;
        dataGridView1.DataBind();
        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
             if (tbl2.DefaultView.FindRows(dataGridView1.DataKeys[i].Value).Length > 0)
                dataGridView1.Rows[i].BackColor = Color.Green;
        }
