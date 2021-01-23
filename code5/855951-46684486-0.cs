        privat string _dataSource = @"H:\Ik.db";
        private SQLiteConnection _connection;
        private SQLiteCommand _command;
        private void connectToSQLite()
        {
            using (SQLiteConnection _connection = new SQLiteConnection())
            {
                if (File.Exists(@"H:\Ik.db"))
                {
                    _connection.ConnectionString = $"Data Source={_dataSource};Version=3";
                    _connection.Open();
                    using (SQLiteCommand _command = new SQLiteCommand())
                    {
                        _command.Connection = _connection;
                        _command.CommandText = "CREATE TABLE IF NOT EXISTS Kunden ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Lastname VARCHAR(100) NOT NULL, " +
                         "name VARCHAR(100) NOT NULL, Code VARCHAR(100) NOT NULL, City VARCHAR(100) NOT NULL);";
                        try
                        {
                            _command.ExecuteNonQuery();
                            MessageBox.Show($"You Connected to local Data Base under {_dataSource} Sucssefuly");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
                else
                {
                    SQLiteConnection.CreateFile(@"H:\Ik.db");
                }
            }
        }
