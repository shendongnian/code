    SqlConnection SqlCon = new SqlConnection("server=" + cboServerName.SelectedItem.ToString() + ";uid=" + txtUsername.Text + ";pwd=" + txtPassword.Text);
            try
            {
                SqlCon.Open();
                //if connection was successful,fetch the list of databases available in that server
                SqlCommand SqlCom = new SqlCommand();
                SqlCom.Connection = SqlCon;
                SqlCom.CommandType = CommandType.StoredProcedure;
                SqlCom.CommandText = "sp_databases";        //sp_databases procedure used to fetch list of available databases
                SqlDataReader SqlDR;
                SqlDR = SqlCom.ExecuteReader();
                while (SqlDR.Read())
                {
                    cboDatabase.Items.Add(SqlDR.GetString(0));
                }
            }
            catch
            {
                MessageBox.Show("Connection Failed...Please check username and password","Error");
            }
