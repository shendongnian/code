    private void keepdata()
    {
        MySqlCommand cmd;
    
        string connString = "server=[Server_Name];database=[Database_Name];user id=[User_Id];pwd=[Password];default command timeout=30000";
        using (var mcon = new MySqlConnection(connString))
        {
            using (cmd = mcon.CreateCommand())
            {
                try
                {
                    mcon.Open();
                    MessageBox.Show("Connect");
    
                }
                catch
                {
                    MessageBox.Show("Not Connect");
                }
            }
            mcon.Close();
        }
    }
