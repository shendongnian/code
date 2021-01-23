    SQLiteConnection sDBConnection = new SQLiteConnection("Data Source=Database.ddb;Version=3");
    sDBConnection.Open();
    string sqlCom = "SELECT * FROM Table1";
    SQLiteCommand scdCommand = new SQLiteCommand(sqlCom, sDBConnection);
    SQLiteDataReader reader = scdCommand.ExecuteReader();
    while(reader.Read())
    {
    string Value1 = reader["Col1"] != null ? Convert.ToString(reader["Col1"]) : string.Empty;
    bool Value2 = true;
    string Value3 = reader["Col2"] != null ? Convert.ToString(reader["Col2"]) : string.Empty;
    object[] row = { Value1, Value2, Value3 };
    DataGridView1.Rows.Add(row);
    }
    reader.Close();
    sDBConnection.Close();
