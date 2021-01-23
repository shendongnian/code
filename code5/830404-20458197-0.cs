    string username = textUsername.Text;
    string password = textPassword.Text;
    
    try
    {
        string cmdText = "SELECT * from ha_system.main where name=@uname AND and password=@pwd";
        using(MySqlConnection myConn = new MySqlConnection(Common.myConnection))
        using(MySqlCommand SelectCommand = new MySqlCommand(cmdText, myConn))
        {
             myConn.Open();
             SelectCommand.Parameters.AddWithValue("@uname", username);
             SelectCommand.Parameters.AddWithValue("@pwd", password);
             using(MySqlDataReader myReader = SelectCommand.ExecuteReader())
             {
                 ....
             }
        }
     }
     catch (Exception ex)
     {
         MessageBox.Show(ex.Message);
     }
