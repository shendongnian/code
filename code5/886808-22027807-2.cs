    using(OleDbConnection con = new OleDbConnection(conn))
    using(OleDbCommand cmd = new OleDbCommand(dbcmd, con))
    using(OleDbDataAdapter da = new OleDbDataAdapter(cmd))
    {
         cmd.Parameters.AddWithValue("@p1", CustomerName);
         DataTable CustAssets = new DataTable();
         da.Fill(CustAssets);
         dataGridView1.DataSource = CustAssets;
    }
