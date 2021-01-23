    public bool LoginQuery(string username, string password)
    {
        string loginquery = "SELECT * FROM logingegevens WHERE Username='" + username + "'AND Password='" + password + "';";
    
        try
        {
    
            MySqlCommand cmd = new MySqlCommand(loginquery, _connection);
    
            MySqlDataReader dataReader = cmd.ExecuteReader();
            int count = 0;
            while (dataReader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                return true;
            }                           
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        
        return false;     
    }
