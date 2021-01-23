	string password = SomeStaticClass.Encrypt(TextBox2.Text);
	string connectionString = "Data Source=TEST-PC\\SQLSERVER2012;Initial     Catalog=oncf;Integrated Security=True";
	string query = "SELECT UserCount = COUNT(*) FROM Account WHERE acc_username= @UserName AND acc_password= @Password";
	
	using (var connection = new SqlConnection(connectionString))
	using (var command = new SqlCommand(query, connection))
	{
		connection.Open();
		command.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = TextBox1.Text;
		command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = password;
		
		int count = Convert.ToInt32(command.ExecuteScalar());
		
		if(count==1)
        {
            Response.Redirect("page2.aspx");
        }
        else
        {
            Label1.Visible = true;
        }
	}
	
