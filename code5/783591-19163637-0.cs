    private const string ConnectionString = "SERVER=YourServer;DATABASE=YourDB;UID=UserName;PASSWORD=UserPassword;";
    using (var mcon = new MySqlConnection(ConnectionString))
                using (var cmd = mcon.CreateCommand())
                {
                    mcon.Open();
                    //you actions
                }
