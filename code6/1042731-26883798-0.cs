    public static void GetQuantity()
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "SELECT [Quantity] FROM [Database]";
    
                    connection.Open();
    
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int quantity = (int)reader["Quantity"];
    
                                UserInformation.Quantity = Convert.ToDecimal(quantity);
                            }
    
                            reader.Close();
                        }
                    }
    
                    connection.Close();
                }
            }
    
            public static void CheckQuantity(CustomToolTip _customToolTip, IWin32Window _window, int _x, int _y, int _duration)
            {
                GetQuantity();
    
                string message = string.Empty;
    
                string productCode = string.Empty;
    
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "SELECT [ProductCode] FROM [Database] WHERE [Quantity] = @Quantity";
    
                    connection.Open();
    
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@Quantity", OleDbType.Decimal);
                        command.Parameters["@Quantity"].Value = UserInformation.Quantity;
    
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                productCode = (string)reader["ProductCode"];
    
                                if (UserInformation.Quantity < 5)
                                {
                                    message += "- Product Code: " + productCode + "\n- Quantity: " + UserInformation.Quantity + "\n\n";
                                }
                            }
    
                            if (message != string.Empty)
                            {
                                SystemManager.SoundEffect("C:/Windows/Media/Speech Off.wav");
    
                                _customToolTip.Show("The system has detected the following: \n\n" + message + "Have quantity less than 5.\nPlease update them immediately.", _window, _x, _y, _duration);
                            }
    
                            reader.Close();
                        }
    
                    }
    
                    connection.Close();
                }
            }
    
     void Timer_Tick(object sender, EventArgs e)
            {
                this.textBox4.Text = DateTime.Now.ToString("dd - MMM - yyyy hh:mm:ss tt");
    
                timeLeft--;
    
                if (timeLeft == 0)
                {
                    _timer.Stop();
    
                    if (UserInformation.Quantity < 5)
                    {
                        SystemManager.CheckQuantity(customToolTip1, this, _screen.Right, _screen.Bottom, 5000);
    
                        timeLeft = 15;
    
                        _timer.Start();
                    }
    
                    else if (UserInformation.Quantity >= 5)
                    {
                        timeLeft = 15;
    
                        _timer.Start();
                    }
                }
            }
