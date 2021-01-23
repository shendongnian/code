    private void admin_submit_button_Click(object sender, EventArgs e) 
    { 
        try 
        { 
           string cmdText = @"select * from mws.login_info 
                             where login_id=@id and login_password1=@pwd
                             and login_password2=@pwd2";
           string myConnection = "datasource= localhost;port=3306;username=root;password=root";
           using(MySqlConnection myConn = new MySqlConnection(myConnection))
           using(MySqlCommand SelectCommand = new MySqlCommand(cmdText, myConnection))
           {
               myConn.Open();
               SelectCommand.Parameters.AddWithValue("@id", this.admin_id_textbox);
               SelectCommand.Parameters.AddWithValue("@pwd",this.admin_password_textbox1);
               SelectCommand.Parameters.AddWithValue("@pwd2",this.admin_password_textbox2);
               using(MySqlDataReader myReader = SelectCommand.ExecuteReader())
               {
                   if(myReader.HasRows)
                       MessageBox.Show("username and password is correct");
                   else
                        MessageBox.Show("username and password not correct");
               }
           }
        }
        catch(Exception ex)
        {
           MessageBox.Show(ex.Message);
        }
