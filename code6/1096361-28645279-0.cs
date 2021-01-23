     bool flag = false;
    	while (myReader.Read())
                {
                    try
                    {
                        if (myReader["username"].ToString() == txtuserid.Text && myReader["password"].ToString() == txtpassword.Text)
                        {
                            // set the flag to true, is credentials match and break from the loop
    						flag = true;
    						break;
    						// set logid to userid
                            logid = loginid(myReader["username"].ToString());
                            string updateCommand = "UPDATE ozturk.admin SET status = 'on' WHERE id='" + logid + "' ";
        
                            MySqlConnection newcon = new MySqlConnection(conString);
                            MySqlCommand cmd2 = new MySqlCommand(updateCommand, newcon);
                            MySqlDataReader myReader2;
                            newcon.Open();
                            myReader2 = cmd2.ExecuteReader();
        
                            Anasayfa anasayf = new Anasayfa();
                            anasayf.Show();
                            this.Hide();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Username or Password is incorrect");
                        throw;
                    }
                }
    			if(!flag)
    			{
    				MessageBox.Show("Username or Password is incorrect");
    			}
