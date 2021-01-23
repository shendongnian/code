    // all you validation if statements
    else
    {
        if(g_i_commitType == 1)
        {
            SqlConnection oConnection = new SqlConnection(_ConnectionString);
            SqlCommand Check_Exist = new SqlCommand("SELECT UserName from UserEnrollment WHERE username = @UserName AND Password = @Password", oConnection);`enter code here`
            Check_Exist.Parameters.AddWithValue("@UserName", txtUserName.Text);
            Check_Exist.Parameters.AddWithValue("@Password", txtPassword.Password);
            oConnection.Open();
            SqlDataReader reader = Check_Exist.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("Username and Password already exist!", "Error Message", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }
    
        int Gender = 0;
        // rest of you code
