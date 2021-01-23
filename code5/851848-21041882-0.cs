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
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.DataBind(); //call the databind method to bound the data to the grid
            //this is not needed
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    dataGridView1.Rows.Add(new DataGridViewRow());
            //    int j;
            //    for (j = 0; j < ds.Tables[0].Columns.Count; j++)
            //    {
            //        dataGridView1.Rows[i].Cells[j].Value = ds.Tables[0].Rows[i][j].ToString();
            //    }
            //}
            con.Close();
        }
