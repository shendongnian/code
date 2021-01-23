     public void WhoLogIn()
        {
            _con.Open();
            MySqlCommand NewCommand = new MySqlCommand("select titleandfullname from users where username ='" + Variables.whologin + "';", _con);
            //Variables.whologin is a public const string in a class declared in another file.
            MySqlDataReader result;
            result = NewCommand.ExecuteReader();
            string _nameofwhologin;
    
            while (result.Read())
            {
                _nameofwhologin = result.GetString(0);
            }
            label2.Text=_nameofwhologin;
    
        }
