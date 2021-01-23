    private void BindCombo()
    {
                cmbdel.Items.Clear(); // Clear the combobox items here
                // And bind again...
                string query = "SELECT * FROM inv.product;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(query, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDatabase.ExecuteReader();
    
                    while (myReader.Read())
                    {
                        string sprodID = myReader.GetString("productID");
                        cmbdel.Items.Add(sprodID);
                    }
                }
    }
