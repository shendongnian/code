    using(SQLiteConnection sqliteCon = new SQLiteConnection(dBConnectionString)
    {
        sqliteCon.Open();
        using(SQLiteCommand createCommand = new SQLiteCommand("SELECT COUNT(*) FROM EmployeeList", sqlliteCon))
        {
             createCommand.CommandType = System.Data.CommandType.Text;
             int RowCount = 0;
             using(SQLiteDataReader reader = createCommand.ExecuteReader())
             {
                 while(reader.Read())
                 {
                     RowCount = reader.GetInt32(0);
                 }
             }
        }
     }
