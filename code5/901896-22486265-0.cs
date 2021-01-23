    string myConnection = "datasource=localhost;port=3307;username=root;password=root";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand command = myConn.CreateCommand();
                command.CommandText = "Select Partylist FROM expertsystem.addcandidate WHERE NumParty=1";
                MySqlDataReader myReader;
    
             try
                {
                    myConn.Open();
                    myReader = command.ExecuteReader();
    
                     while (myReader.Read())
            {
                lblpartylist1.Text = myReader[0].ToString();
    
                }
             }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                myConn.Close();
