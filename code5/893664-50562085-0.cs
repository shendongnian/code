                try
                {
                    string myConnection = "datasource=localhost;port=3306;username=root;password=1234";
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlCommand SelectCommand = new MySqlCommand(" select * from boardinghousedb.employee_table where username='" + this.txtUsername.Text + "' AND password='" + this.txtPassword.Text + "' ;", myConn);
                    MySqlDataReader myReader;
                    myConn.Open();
                    myReader = SelectCommand.ExecuteReader();
                    int count = 0;
                    bool IsAdminUser = false;
                    while (myReader.Read())
                    {
                        count = count + 1;
                        IsAdminUser = myReader["username"].ToString().Equals("admin");
                    }
                    if (count == 1 && IsAdminUser == true)
                    {
                        MessageBox.Show("User is Admin!");
                        this.Hide();
                        AdminForm adminForm = new AdminForm();
                        adminForm.ShowDialog();
                    }
                    else if (count == 1)
                    {
                       
                        this.Hide();
                        Menu f3 = new Menu();
                        f3.ShowDialog();
                    }
                    
                    else if (count > 1)
                    {
                        MessageBox.Show("Duplicate Username and Password . . . Access Denied", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Username and Password is Not Correct . . . Please try again", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        myConn.Close();
                    }
                   
                    myConn.Close();
                 }
                     catch (Exception ex)
                    {
                    MessageBox.Show(ex.Message);
                    }     
        }
