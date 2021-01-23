      private void LoadClient()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Pigen"].ConnectionString;
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
        }
