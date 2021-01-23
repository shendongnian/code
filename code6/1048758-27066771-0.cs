    string connectionString = "datasource = localhost; port = 3306; username = root; password = Mypass;";
    using(MySqlConnection myConn = new MySqlConnection(connectionString))
    using(MySqlCommand selectCommand = new MySqlCommand())
    {
        selectCommand.Text = "SELECT COUNT(1) FROM dark_heresy.users WHERE users_=? and password_=?;", myConn);
        myConn.Open();
        var ret = selectCommand.ExecuteScalar();
        count = Int32.Convert(ret);
        if (count == 1)
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
