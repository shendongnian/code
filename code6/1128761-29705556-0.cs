     private void ButtonFieldHelp_Click(object sender, EventArgs e)
        {
            char ch = '"';
            var dbConn = new OleDbConnection();
            var dbCmd = new OleDbCommand();
            DataTable data = new DataTable();
            OleDbDataReader reader;
            dbConn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ch + this.stringData + ch;
            dbConn.Open();
            dbCmd.Connection = dbConn;
            dbCmd.CommandText = "SELECT * FROM " + this.comboBox.SelectedItem.ToString();
            //reader = dbCmd.ExecuteReader();
            OleDbDataAdapter adapter = new OleDbDataAdapter(dbCmd);
            adapter.Fill(data);
            var dataTable = new DataTable();
            dataTable.Columns.Add("ColumnName");
            dataTable.Columns.Add("ColumnType");
            foreach (DataColumn column in data.Columns)
            {
                dataTable.Rows.Add(column.ColumnName, column.DataType.ToString());
            }
            this.dataGridView1.DataSource = dataTable;
            this.txtRecords.Text = data.Rows.Count.ToString();
            dbConn.Close();
        }
