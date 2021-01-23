    const string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"{0}\"";
    
    const string DBFile = "Database.mdb";
    public void AddNewUser()
    {
        string conString = string.Format(ConnectionString, Path.Combine(Application.StartupPath, DBFile));
        using (var connection = new System.Data.OleDb.OleDbConnection(conString))
        {
            try
            {
                string sql = "UPDATE enroll SET SSN=@ssn, FirstName=@firstName, LastName=@lastName WHERE ID=@userID";
                System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand(sql, connection);
                command.Parameters.AddWithValue("@ssn", txtSSN.Text);
                command.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                command.Parameters.AddWithValue("@lastName", txtLastName.Text);
                command.Parameters.AddWithValue("@userID", _UserID);
    
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Student added successfully!", "Registered");
    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
            finally
            {
                connection.Close();
            }
        }
    }
