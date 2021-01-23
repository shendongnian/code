    private void button1_Click(object sender, EventArgs e)
    {
        SqlConnection sc = new SqlConnection();
        SqlCommand com = new SqlCommand();
        sc.ConnectionString = ("My Connection String");
        sc.Open();
        com.Connection = sc;
        /// check for original value in whereClause
        com.CommandText = ("update JoshUserTable SET UserID = @NEW_UserID,
                            FirstName=@FirstName,LastName=@LastName,Email=@Email
                            where UserID = @ORIGINAL_UserID");
        com.Parameters.AddWithValue("@NEW_UserID", txtUserID.Text);
        com.Parameters.AddWithValue("@ORIGINAL_UserID", INSERT_ORIGINAL_USERID);
        com.Parameters.AddWithValue("@FirstName", txtFName.Text);
        com.Parameters.AddWithValue("@LastName", txtLName.Text);  
        com.Parameters.AddWithValue("@Email", txtEmail.Text);  
        com.ExecuteNonQuery();
        sc.Close();
    }
