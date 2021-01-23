    private void btnLogin_Click(object sender, EventArgs e)
    {
    try
    {
        string strConnect = "Server=***.***.***.**;Port=3306;Database=cpr_users;Uid=********;Pwd=********;";
        using (MySqlConnection myConn = new MySqlConnection(strConnect))
        using (MySqlCommand selectCommand = new MySqlCommand())
        {
            // You need to select all the records instead of COUNT(*)
            selectCommand.CommandText = "SELECT * FROM cpr_users.cpr_user_info WHERE username=@User and password=@Password";
            selectCommand.Connection = myConn;
            selectCommand.Parameters.Add("@User", MySqlDbType.VarChar).Value = txtUsername.Text; 
            selectCommand.Parameters.Add("@Password", MySqlDbType.VarChar).Value = txtPassword.Text; 
            myConn.Open();
            MySqlDataReader myReader = selectCommand.ExecuteReader();
            // If there is a record   
            if(myReader.Read()) 
            {
				var hashedPW = Security.HashSHA256(txtPassword.Text);
				var stored = myReader["password"].ToString();
				Int32 count = (Int32)selectCommand.ExecuteScalar();
				if (count == 1 & hashedPW == stored)
				{
					MessageBox.Show("Connection Successful");
				}
				else if (count > 1)
				{
					MessageBox.Show("Duplication of Username and Password... Access Denied");
				}
				else
				{
					MessageBox.Show("Incorrect Username and/or Password");
				}
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
