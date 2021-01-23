    private static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database/Health.accdb";
    public static void AutoComplete(AutoCompleteStringCollection _collections)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "SELECT DISTINCT [Description] FROM [Database] ORDER BY [Description] ASC";
    
                    connection.Open();
    
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _collections.Add(reader["Description"].ToString());
                        }
    
                        reader.Close();
                    }
    
                    connection.Close();
    
                }
            }
    public static void GetData(TextBox _windowsTextBox1, TextBox _windowsTextBox2, TextBox _windowsTextBox3, NumericUpDown _numericUpDown1)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "SELECT [ProductCode], [Description], [Quantity], [Price] FROM [Database] WHERE [Description] = @Description";
    
                    connection.Open();
    
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@Description", OleDbType.VarChar);
                        command.Parameters["@Description"].Value = _windowsTextBox1.Text;
    
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string productCode = (string)reader["ProductCode"];
                                string description = (string)reader["Description"];
    
                                UserInformation.Description = description;
    
                                int quantity = (int)reader["Quantity"];
                                int price = (int)reader["Price"];
    
                                _windowsTextBox2.Text = productCode;
    
                                _windowsTextBox3.Text = Convert.ToString(price);
    
                                _numericUpDown1.Maximum = Convert.ToDecimal(quantity);
                            }
    
                            reader.Close();
                        }
                    }
    
                    connection.Close();
    
                }
            }
