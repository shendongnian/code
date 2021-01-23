    private void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string strConnect = "Server=***.***.***.**;Port=3306;Database=cpr_users;Uid=********;Pwd=********;";
            using (MySqlConnection myConn = new MySqlConnection(strConnect))
            using (MySqlCommand selectCommand = new MySqlCommand())
            {
                selectCommand.CommandText = @"SELECT COUNT(*) 
                                             FROM cpr_users.cpr_user_info 
                                             WHERE username=@User and password=@Password";
                selectCommand.Connection = myConn;
                selectCommand.Parameters.Add("@User", MySqlDbType.VarChar).Value = txtUsername.Text; 
                selectCommand.Parameters.Add("@Password", MySqlDbType.VarChar).Value = Security.HashSHA256(txtPassword.Text);
                object result = selectCommand.ExecuteScalar();
                if (result != null)
                {
                    int count = Convert.ToInt32(result);
                    if(count > 0) 
                       MessageBox.Show("Connection Successful");
                    else
                       MessageBox.Show("Incorrect Username and/or Password");
                }
                else
                {
                    MessageBox.Show("Incorrect Username and/or Password");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
