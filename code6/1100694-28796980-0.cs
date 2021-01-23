     string insertString = "INSERT INTO TabelaUtilizatori (name, password) VALUES('"+UserID+"', '"+UserPas+"')";
            string selectString = "SELECT COUNT(*) FROM TabelaUtilizatori where name=" + "'" + UserID + "'";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(selectString, connection);
                int Result = 0;
                Result = Convert.ToInt32(cmd.ExecuteScalar());
                if (Result == 1)
                {
                    MessageBox.Show("Username Already Exists");
                    this.CloseConnection();
                }
                else{
                  MySqlCommand cmdInsert = new MySqlCommand(insertString, connection);
                cmdInsert.ExecuteNonQuery();
                this.CloseConnection();
                MessageBox.Show("Inregistration Sucessful");
                }
              
            }
