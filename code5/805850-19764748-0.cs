    string User_Username = Session["Username"].ToString();
    string User_FirstName = FirstNameEdit.Text;
    string User_LastName = LastNameEdit.Text;
    
    string cnnStr = "Data Source=localhost;Initial Catalog=Break; Integrated Security=True";
    
    using (SqlConnection connection = new SqlConnection(cnnStr))
    {
       //Commented as not using
       //SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
       //command.Connection.Open();
    
       string querystr = "UPDATE Users SET User_FirstName = @FirstName, User_LastName= @LastName " +
                         "WHERE   User_Username = @Username";
       SqlCommand query = new SqlCommand(querystr, connection);
    
       //Add a new SqlParameter()...
       query.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar)).Value = User_Username;
       query.Parameters.Add(new SqlParameter("@Firstname", SqlDbType.NVarChar)).Value = User_FirstName;
       query.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar)).Value = User_LastName;
    
       connection.Open();
       query.ExecuteNonQuery();
    }
    
    //Rest of the code
    Session.Add("FirstName", User_FirstName);
    Session.Add("LastName", User_LastName);
    StatusMessage.Text = "Updated!";
