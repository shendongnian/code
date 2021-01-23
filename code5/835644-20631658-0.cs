    //Assign the all available credentials to the connection string variable.
            var myConnectionString = "SERVER=" + txtServer.Text + ";UID=" + txtName.Text + ";" + "pwd=" + txtPass.Text + ";";
            try
            {
                //if MySQL database selected.
            if (cmbDBType.SelectedIndex == 2)
            {
                cmbDataSource.Visible = false;
                txtServer.Visible = true;
                //Providing connection string.
                var connection = new MySqlConnection(myConnectionString);
                var command = connection.CreateCommand();
                //command to select all database from MySQL
                command.CommandText = "SHOW DATABASES;";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var row = "";
                    for (var i = 0; i < reader.FieldCount; i++)
                        row += reader.GetValue(i);
                    //Adding the database in comboBox.
                    cmbDatabase.Items.Add(row);
                }
                connection.Close();
            }
            }
            catch (Exception)
            {
                //if failed.
                MessageBox.Show(@"Connection Failed...Please check the credentials", @"Error");
            }
