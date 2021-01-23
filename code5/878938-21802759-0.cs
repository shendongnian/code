    private void comboBox1_SelectedItem(object sender, EventArgs e)
            {
                MessageBox.Show("Populating form");
                m_dbConnection.Open();
                     
                DataTable dt = new DataTable();
                SQLiteCommand command = m_dbConnection.CreateCommand();
                command.CommandText = "select * from rdpdirectory where company = @company order by company asc";
                //
                command.Parameters.Add(new SQLiteParameter("@company", comboBox1.SelectedText));
                SQLiteDataAdapter db = new SQLiteDataAdapter(command);
                db.Fill(dt);
                //return dt;
    
    
                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = dt.Columns["company"];
                dt.PrimaryKey = keyColumns;
    
                DataRow row = dt.Rows[0];
                txtCompany.Text = row["company"].ToString();
                txtServer.Text = row["server"].ToString();
                txtUserName.Text = row["username"].ToString();
                txtPassword.Text = row["password"].ToString();
            }
