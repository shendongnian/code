    DateTime currentDateTime = DateTime.MinValue;
    using (DbCommand command = database.GetSqlStringCommand("SELECT GETDATE()"))
    {
        using (IDataReader dataReader = (IDataReader)database.ExecuteReader(command))
        {
            if (dataReader.Read())
            {
                currentDateTime = (DateTime)dataReader[0];
            }
        }
    }
    
    TimeSpan from = new TimeSpan(8, 0, 0); // 8am
    TimeSpan to = new TimeSpan(24, 0, 0); // 12pm
    bool canOrderNow = currentDateTime != DateTime.MinValue && currentDateTime.TimeOfDay >= from && currentDateTime.TimeOfDay < to;
