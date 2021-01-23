    using(SqlConnection connection = new SqlConnection("yourConnectionString"))
    using (
        SqlCommand command =
            new SqlCommand(
                "SELECT * FROM [employeeAccount] WHERE [UserName] = @userName AND [Password] = @password",
                connection))
    {
        command.Parameters.AddWithValue("@username", txtUserName.Text);
        command.Parameters.AddWithValue("@password", txtPassword.Text);
        connection.Open();
        //,... execute command
    }
