    sqlite_Conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
        sqlite_Conn.Open();
        sqlite_CreateCmd = new SQLiteCommand();
        sqlite_InsertCmd = new SQLiteCommand();
        sqlite_QueryCmd = new SQLiteCommand();
        sqlite_CreateCmd.Connection = sqlite_Conn;
        sqlite_InsertCmd.Connection = sqlite_Conn;
        sqlite_QueryCmd.Connection = sqlite_Conn;
        sqlite_CreateCmd.CommandText = "CREATE TABLE test (id integer primary key, text varchar(100));";
        sqlite_InsertCmd.CommandText = "INSERT INTO test (id, text) VALUES (1,'Test Text 1');";
        sqlite_QueryCmd.CommandText = "SELECT * FROM test";
        sqlite_CreateCmd.ExecuteNonQuery();
        sqlite_InsertCmd.ExecuteNonQuery();
        sqlite_DataRdr = sqlite_QueryCmd.ExecuteReader();
        while (sqlite_DataRdr.Read())
        {
            System.Console.WriteLine(sqlite_DataRdr["text"]);
        }
        sqlite_Conn.Close();
