    public bool loginfun()
        {
            string conString ="Server=localhost;Database=ozturk;Uid=_____;pwd=_____";
            MySqlConnection mcon = new MySqlConnection(conString);
            string selectCommand = "SELECT * FROM ozturk.admin";
            MySqlCommand cmd = new MySqlCommand(selectCommand,mcon);
            MySqlDataReader myReader;
            mcon.Open();
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                try
                {
                    if (myReader["username"].ToString() == txtuserid.Text && myReader["password"].ToString() == txtpassword.Text)
                    {
                        // giriş yapan kişinin id si
                        logid = loginid(myReader["username"].ToString());
                        string updateCommand = "UPDATE ozturk.admin SET status = 'on' WHERE id='" + logid + "' ";
                        MySqlConnection newcon = new MySqlConnection(conString);
                        MySqlCommand cmd2 = new MySqlCommand(updateCommand, newcon);
                        MySqlDataReader myReader2;
                        newcon.Open();
                        myReader2 = cmd2.ExecuteReader();
                        
                        return true;
                    }
                    
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    throw;
                }
            }
            return false;
                    
        }
