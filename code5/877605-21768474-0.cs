    private void SQLComboBox_MouseDown(object sender, EventArgs e)
        {
            SqlDataSourceEnumerator sdse = SqlDataSourceEnumerator.Instance;
            DataTable table = sdse.GetDataSources();
            foreach (DataRow row in table.Rows)
            {
                SQLComboBox.Items.Add(row["ServerName"].ToString() + "\\" + row["InstanceName"].ToString());
            }
        }
