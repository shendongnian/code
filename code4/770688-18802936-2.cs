    public bool? Authenticate(string personID, string firstName)
    {
        try
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM yourTable";
            MySqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader[0].ToString() == personID) //first check if the ID is equal
                {
                    if (Reader[1].ToString() == firstName) //if ID is equal, check if firstName is equal
                    {
                        connection.Close();
                        return true; 
                    }
                }
            }
            connection.Close();
            return false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return null;
        }
    }
