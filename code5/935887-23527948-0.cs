    OleDbCommand com = new OleDbCommand("SELECT count(*) from DI WHERE [Task] = ? AND [Time_Off] is null", Program.DB_CONNECTION);
    com.Parameters.Add(new OleDbParameter("", "DI"));
    int count = (int)com.ExecuteScalar();
    if (count > 0)
    {
        OleDbCommand com1 = new OleDbCommand("UPDATE DI SET [Time_OFF] = ? WHERE [Task] = ? AND [Time_Off] is null", Program.DB_CONNECTION);
        com1.Parameters.Add(new OleDbParameter("", DateTime.Now.TimeOfDay));
        com1.Parameters.Add(new OleDbParameter("", "DI"));
        com1.ExecuteNonQuery();
    }
    else
    {
        DIPerson = DIlist[DIcomboBox.SelectedIndex];
    
        OleDbCommand com2 = new OleDbCommand("INSERT INTO DI ([Person], [Task], [Time_On]) VALUES     (?, ?, ?)", Program.DB_CONNECTION);
        com2.Parameters.Add(new OleDbParameter("", DIPerson.ID));
        com2.Parameters.Add(new OleDbParameter("", "DI"));
        com2.Parameters.Add(new OleDbParameter("", DateTime.Now.TimeOfDay));
    
        com2.ExecuteNonQuery();
    }
