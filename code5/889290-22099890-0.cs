    sqliteCon.Open();
    SQLiteCommand createCommand = new SQLiteCommand("SELECT COUNT(*) FROM EmployeeList", sqlliteCon);
    createCommand.CommandType = CommandType.Text;
    int RowCount = 0;
    using(SQLiteDataReader reader = createCommand.ExecuteReader())
    {
         while(reader.Read())
         {
            RowCount = reader.GetInt32(0);
         }
    }
