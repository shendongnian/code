    SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Break; Integrated Security=True");
    SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
    command.Connection.Open();
    
    string querystr = "UPDATE Users SET User_FirstName = @FirstName, User_LastName= @LastName WHERE User_Username = @Username";
    SqlCommand query = new SqlCommand(querystr, connection);
    
    string User_Username = Session["Username"].ToString();
    string User_FirstName = FirstNameEdit.Text;
    string User_LastName = LastNameEdit.Text;
    
    // changed the order of adding values here
    query.Parameters.Add("@FirstName", User_FirstName);
    query.Parameters.Add("@LastName", User_LastName);
    query.Parameters.Add("@Username", User_Username);
    
    query.ExecuteNonQuery();
    
    Session.Add("FirstName", User_FirstName);
    Session.Add("LastName", User_LastName);
    
    StatusMessage.Text = "Updated!";
    
    command.Connection.Close();
