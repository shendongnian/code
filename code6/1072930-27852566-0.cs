        connection = new MySqlConnection(connectionString);
        if (this.OpenConnection() == true)
        {
            MySqlCommand sqlCmd = new MySqlCommand("sp_clientgridview", connection);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            mySqlDataAdapter = new MySqlDataAdapter(sqlCmd);
            DataSet DS = new DataSet();
            mySqlDataAdapter.Fill(DS);
            sqlCmd.ExecuteNonQuery();
            kryptonDataGridView1.DataSource = DS.Tables[0];
            kryptonDataGridView1.Columns[0].Visible = false;
            kryptonDataGridView1.Columns[2].Visible = false;
    }
    private void frmClient_Load_1(object sender, EventArgs e)
    {
      LoadClient();
    }
    //In Update button:
    private void btnUpdate_Click(object sender, EventArgs e)
    {
      frmUpdate frm = new frmUpdate();
      frm.ShowDialog()
      //refresh the datagridview by call again the LoadClient();
      LoadClient();
    }
