    private void Bind()
    {
        OleDbConnection con = new OleDbConnection(constr);
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = con;
        cmd.CommandText = "select * from tb1";
        cmd.CommandType = CommandType.Text;
        OleDbDataAdapter da = new OleDbDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            var row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            
            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {
                row.Cells[j].Value = ds.Tables[0].Rows[i][j].ToString();
            }
            dataGridView1.Rows.Add(row);
        }
        con.Close();
    }
