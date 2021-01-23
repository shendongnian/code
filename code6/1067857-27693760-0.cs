    public static void CheckQuantity(CustomToolTip _customToolTip, IWin32Window _window, 
                                     int _x, int _y, int _duration)
    {
        string message = string.Empty;
    
        string productCode = string.Empty;
        int quantity;
    
        string query =
            "SELECT [ProductCode], [Quantity] FROM [Database] " +
            "WHERE [Quantity] = < 5 ORDER BY [ProductCode] ASC";
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        using (OleDbCommand command = new OleDbCommand(query, connection))
        using (OleDbDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                productCode = (string)reader["ProductCode"];
                quantity = (int)reader["Quantity"];
                          
                message += "- Product Code: " + productCode + 
                           "\n- Quantity: " + quantity + "\n\n";
            }
            reader.Close();
            connection.Close();
        }
    
        if (message != string.Empty)
        {
            SystemManager.SoundEffect(@"\Media\Speech Off.wav");
    
            string _message1 = "The system has detected the following: \n\n";
            string _message2 = "Have quantity less than 5.\nPlease update them immediately.";
    
            _customToolTip.Show(_message1 + message + _message2, _window, 
                                _x, _y, _duration);
        }
    }
