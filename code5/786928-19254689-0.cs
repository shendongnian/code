        if (checkPasswordsMatch() == "B")
            {
                SqlCeConnection myConnection = new SqlCeConnection("Data Source = pwdb.sdf");
                        try
                        {
                            myConnection.Open();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        SqlCeCommand myCommand = myConnection.CreateCommand();
                        myCommand.CommandType = CommandType.Text;
    myCommand.CommandText = "INSERT INTO PW Values ('Master', '" + saltedcryps + "', '" + hashedResult + "');"
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                        this.Hide();
    
            }
