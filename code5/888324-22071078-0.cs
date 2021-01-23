    SqlDataReader Reader = null;
    SqlConnection Connection = null;
    SqlCommand Command = null;
    string ConnectionString = "YourConnectionString";
    string CommandText = "SELECT USER_ID  AS [UserID] FROM MySQLtable";
            
    Connection = new SqlConnection(ConnectionString);
    Connection.Open();
    Command = new SqlCommand(CommandText, Connection);
    Reader = Command.ExecuteReader();
    DataTable test= new DataTable();
    test.Load(Reader);
         
    Reader.Close();
    Command.Dispose();
    Connection.Close();
