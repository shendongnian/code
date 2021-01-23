    // It's not clear what cateName is, but I'll assume *that* bit is valid...
    string sql = new SQLiteCommand("insert into " + cateName +
         " (Name, DateCreated, Reminder, Content) values " +
         "(@Name, @DateCreated, @Reminder, @Content)");
    using (var command = new SQLiteCommand(sql, connection))
    {
        command.Parameters.Add("@Name", SQLiteType.Text).Value = noteName;
        command.Parameters.Add("@DateCreated", SQLiteType.DateTime).Value = currentDate;
        command.Parameters.Add("@Reminder", SQLiteType.Text).Value = reminder;
        command.Parameters.Add("@Content", SQLiteType.Text).Value = content;
        command.ExecuteNonQuery();
    }
