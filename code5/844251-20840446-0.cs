    var connectionString = "connection string goes here";
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT Id FROM Customers";
            using (var command = new MySqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    //Iterate through the rows and add it to the combobox's items
                    while (reader.Read())
                    {
                        CustomerIdComboBox.Items.Add(reader.GetString("Id"));    
                    }
                }    
            }
        }
