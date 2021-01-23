    private void btnLogin_Click(object sender, EventArgs e)
    {
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\ProgII Project\MoneyManager\MoneyManager\MsUser.mdf;Integrated Security=True;User Instance=True");
    
            SqlCommand cmd1 = new SqlCommand("Select Count(*) From MsUser where username = @username and password = @passowrd", cn);
            cmd1.Parameters.AddWithValue("@username", idBox.Text.Trim());
            cmd1.Parameters.AddWithValue("@passowrd", passwordBox.Text.Trim());            
            
            int returnValue = Convert.ToInt32(cmd1.ExecuteScalar());
    
            if (returnValue == 1)
            {
                 this.Hide();
            }
            else
            {
                MessageBox.Show("your id or password is wrong");
            }
     }
