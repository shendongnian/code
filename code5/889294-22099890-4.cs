    using(SQLiteConnection sqliteCon = new SQLiteConnection(dBConnectionString))
    {
        sqliteCon.Open();
        using(SQLiteCommand createCommand = new SQLiteCommand("SELECT COUNT(*) FROM EmployeeList", sqlliteCon))
        {
             createCommand.CommandType = System.Data.CommandType.Text;
             int RowCount = 0;
             RowCount = Convert.ToInt32(createCommand.ExecuteScalar());
             
        }
     }
