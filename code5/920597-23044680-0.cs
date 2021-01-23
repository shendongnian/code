    public void fillCombo(string query, string name, ComboBox c)
            {
                MySqlCommand cmdReader = new MySqlCommand(query,conn);
                MySqlDataReader myReader;
    
                myReader = cmdReader.ExecuteReader(); 
    
                while(myReader.Read())
                {
                    string temp = myReader.GetString(name);
                    c.Items.Add(temp); 
                }
            }
            myReader.Close();
